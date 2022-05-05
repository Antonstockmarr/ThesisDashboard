using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dashboardbackend.Data.ApproachToolRepo;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
    public class SolutionService : ISolutionService
    {
        private IApproachToolRepository _approachTools;

        private IEnumerable<Approach> testApproaches = new List<Approach>
        {
            new Approach
            {
                Id = 1, Name="name", Description="desc", ImplementationDifficulty="easy", MaintenanceDifficulty="easy"
            }
        };

        private IEnumerable<ApproachTool> testApproachTools = new List<ApproachTool>
        {
            new ApproachTool
            {
                Id = 1, ApproachId = 1, ToolId = 1, ConfigurationDifficulty = 4, Tool = new Tool { Id = 1, Name = "tool", Description = "desc"
                }
            },
            new ApproachTool
            {
                Id = 2, ApproachId = 1, ToolId = 2, ConfigurationDifficulty = 3, Tool = new Tool { Id = 2, Name = "tool", Description = "desc"
                }
            }
        };


        public SolutionService(IApproachToolRepository approachTools)
        {
            _approachTools = approachTools;
        }

        public List<Tool> ComputeSolution(List<Approach> approaches)
        {
            //approaches = testApproaches.ToList();
            Dictionary<List<Tool>, int> combinations = new Dictionary<List<Tool>, int>();

            FindToolCombinations(combinations, approaches, new List<Tool>(), 0);
            int minumumScore = 9999;
            List<Tool> tools = new List<Tool>();
            foreach (KeyValuePair<List<Tool>, int> keyValue in combinations) 
            {
                if (minumumScore > keyValue.Value)
                {
                    minumumScore = keyValue.Value;
                    tools = keyValue.Key;
                }
            }

            return tools;
        }

        private void FindToolCombinations(Dictionary<List<Tool>, int> combinations, List<Approach> approaches, List<Tool> tools, int score)
        {
            List<Tool> toolsCopy = new List<Tool>(tools);

            if (!approaches.Any())
            {
                combinations.Add(toolsCopy, score);
                return;
            }

            List<Approach> approachesCopy = new List<Approach>(approaches);

            Approach approach = approachesCopy.ElementAt(0);
            approachesCopy.RemoveAt(0);

            List<Tool> approachTools = GetApproachTools(approach.Id);
            foreach (Tool tool in approachTools)
            {
                toolsCopy.Add(tool);
                int difficulty = GetApproachToolDifficulty(approach.Id, tool.Id);
                score += difficulty;

                FindToolCombinations(combinations, approachesCopy, toolsCopy, score);

                toolsCopy.Remove(tool);
                score -= difficulty;
            }
        }

        private List<Tool> GetApproachTools(int approach)
        {
            IEnumerable<Tool> tools = from n in _approachTools.GetAllApproachTools()
            where n.ApproachId == approach
            select n.Tool;

            return tools.ToList();
        }

        private int GetApproachToolDifficulty(int approach, int tool)
        {
            return (from n in _approachTools.GetAllApproachTools()
                   where n.ApproachId == approach && n.ToolId == tool
                   select n.ConfigurationDifficulty).First();
        }

    }
}
