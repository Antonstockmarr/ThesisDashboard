using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dashboardbackend.Data.ApproachToolRepo;
using Dashboardbackend.Data.ToolRepo;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
    public class SolutionService : ISolutionService
    {
        private IApproachToolRepository _approachTools;

        public SolutionService(IApproachToolRepository approachTools)
        {
            _approachTools = approachTools;
        }

        public List<ApproachTool> ComputeSolution(List<Approach> approaches)
        {
            Dictionary<List<ApproachTool>, int> solutions = new Dictionary<List<ApproachTool>, int>();

            FindSolutions(solutions, approaches, new List<ApproachTool>());
            int minumumScore = 999999;
            List<ApproachTool> approachTools = new List<ApproachTool>();
            foreach (KeyValuePair<List<ApproachTool>, int> keyValue in solutions) 
            {
                if (minumumScore > keyValue.Value)
                {
                    minumumScore = keyValue.Value;
                    approachTools = keyValue.Key;
                }
            }

            return approachTools;
        }

        private void FindSolutions(Dictionary<List<ApproachTool>, int> solutions, List<Approach> approaches, List<ApproachTool> solution)
        {
            List<ApproachTool> solutionCopy = new List<ApproachTool>(solution);

            if (!approaches.Any())
            {
                int score = computeDifficulty(solutionCopy);
                solutions.Add(solutionCopy, score);
                return;
            }

            List<Approach> approachesCopy = new List<Approach>(approaches);

            Approach approach = approachesCopy.ElementAt(0);
            approachesCopy.RemoveAt(0);

            List<ApproachTool> approachTools = GetApproachTools(approach.Id);
            foreach (ApproachTool approachTool in approachTools)
            {
                solutionCopy.Add(approachTool);
                FindSolutions(solutions, approachesCopy, solutionCopy);
                solutionCopy.Remove(approachTool);
            }
        }

        private int computeDifficulty(List<ApproachTool> solution)
        {
            int numberOfTools = solution.ConvertAll(approachTool => approachTool.ToolId).Distinct().Count();
            int difficultySum = solution.Sum(approachTool => approachTool.ConfigurationDifficulty);

            return numberOfTools * 100 + difficultySum;
        }

        private List<ApproachTool> GetApproachTools(int approach)
        {
            IEnumerable<ApproachTool> approachTools = from n in _approachTools.GetAllApproachTools()
            where n.ApproachId == approach
            select n;

            return approachTools.ToList();
        }
    }
}
