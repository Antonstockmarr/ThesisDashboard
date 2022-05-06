using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboardbackend.Models;

namespace Dashboardbackend.Data
{
    public class DataSeeder
    {
        private ApplicationContext _context;

        public DataSeeder(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (!_context.objectives.Any() && !_context.concerns.Any() && !_context.approaches.Any() && !_context.tools.Any() && !_context.approachTools.Any())
            {
                _context.AddRange(GetObjectives());
                await _context.SaveChangesAsync();
                _context.AddRange(GetConcerns());
                await _context.SaveChangesAsync();
                _context.AddRange(GetApproaches());
                await _context.SaveChangesAsync();
                _context.AddRange(GetTools());
                await _context.SaveChangesAsync();
                _context.AddRange(GetApproachTools());
                await _context.SaveChangesAsync();
            }
        }

        private List<Objective> GetObjectives()
        {
            return new List<Objective>()
            {
                new Objective()
                {
                    Name = "User Experience",
                    Description = "desc"
                },
                new Objective()
                {
                    Name = "Incident Management",
                    Description = "desc"
                },
                new Objective()
                {
                    Name = "Resource Management",
                    Description = "desc"
                }
            };
        }

        private List<Concern> GetConcerns()
        {
            return new List<Concern>
            {
                new Concern()
                {
                    Name = "Availability",
                    Description = "desc",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "User Experience").Id
                },
                new Concern()
                {
                    Name = "Performance",
                    Description = "desc",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "User Experience").Id
                },
                new Concern()
                {
                    Name = "User Behaviour",
                    Description = "desc",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "User Experience").Id
                },
                new Concern()
                {
                    Name = "Error Management",
                    Description = "desc",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "Incident Management").Id
                },
                new Concern()
                {
                    Name = "Network Security",
                    Description = "desc",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "Incident Management").Id
                },
                new Concern()
                {
                    Name = "Scalability",
                    Description = "desc",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "Resource Management").Id
                },new Concern()
                {
                    Name = "Capacity Planning",
                    Description = "desc",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "Resource Management").Id
                }
            };
        }

        private List<Approach> GetApproaches()
        {
            return new List<Approach>
            {
                new Approach()
                {
                    Name = "Health checks",
                    Description = "Periodically ping services to see if they are up",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Availability").Id
                },
                new Approach()
                {
                    Name = "Network Traffic Performance",
                    Description = "Monitor CPU, storage and memory usage",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Performance").Id
                },
                new Approach()
                {
                    Name = "Network Traffic Security",
                    Description = "Monitor network log to analyse traffic and identify malicious activity.",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Network Security").Id
                },
                new Approach()
                {
                    Name = "Network Traffic Scalability",
                    Description = "desc",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Network Security").Id
                },
                new Approach()
                {
                    Name = "Distributed Tracing Performance",
                    Description = "Track requests across services to link events and produce timelines",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Performance").Id
                },
                new Approach()
                {
                    Name = "Distributed Tracing User",
                    Description = "Track requests across services to link events and produce timelines",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "User Behaviour").Id
                },
                new Approach()
                {
                    Name = "Distributed Tracing Error",
                    Description = "Track requests across services to link events and produce timelines",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Error Management").Id
                },
                new Approach()
                {
                    Name = "Error Logs",
                    Description = "Logs that are produced within the application. This requires source code instrumentation.",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Error Management").Id
                },
                new Approach()
                {
                    Name = "Alert System",
                    Description = "Send alerts to stakeholders as reaction to specific events or thresholds.",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Error Management").Id
                },
                new Approach()
                {
                    Name = "OS Metrics Scalability",
                    Description = "Metrics on how the services are running, like latency, throughput, etc",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Scalability").Id
                },
                new Approach()
                {
                    Name = "OS Metrics Capacity",
                    Description = "Metrics on how the services are running, like latency, throughput, etc",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Capacity Planning").Id
                }
            };
        }

        private List<Tool> GetTools()
        {
            return new List<Tool>
            {
                new Tool()
                {
                    Name = "Logstash",
                    Description = "Logging",
                    //Approaches = new List<Approach> { new Approach() {Id =_context.approaches.First(approach => approach.Name == "Error logs").Id }}
                },
                new Tool()
                {
                    Name = "Grafana Loki",
                    Description = "Logging",
                    //Approaches = new List<Approach> { new Approach() {Id =_context.approaches.First(approach => approach.Name == "Error logs").Id }}
                },
                new Tool()
                {
                    Name = "Prometheus",
                    Description = "Metrics",
                    //Approaches = new List<Approach> { new Approach() {Id =_context.approaches.First(approach => approach.Name == "Alert System").Id },
                    //                                  new Approach() {Id =_context.approaches.First(approach => approach.Name == "Network Traffic Performance").Id },
                    //                                  new Approach() {Id =_context.approaches.First(approach => approach.Name == "Network Traffic Security").Id },
                    //                                  new Approach() {Id =_context.approaches.First(approach => approach.Name == "Network Traffic Scalability").Id },
                    //                                  new Approach() {Id =_context.approaches.First(approach => approach.Name == "OS Metrics Scalability").Id },
                    //                                  new Approach() {Id =_context.approaches.First(approach => approach.Name == "OS Metrics Capacity").Id }}
                },
                new Tool()
                {
                    Name = "Netdata",
                    Description = "Metrics",
                    //Approaches = new List<Approach> { new Approach() {Id =_context.approaches.First(approach => approach.Name == "Health checks").Id },
                    //                                  new Approach() {Id =_context.approaches.First(approach => approach.Name == "OS Metrics Scalability").Id },
                    //                                  new Approach() {Id =_context.approaches.First(approach => approach.Name == "OS Metrics Capacity").Id }}
                },
                new Tool()
                {
                    Name = "Jaeger",
                    Description = "Distributed Tracing",
                    //Approaches = new List<Approach> { new Approach() {Id =_context.approaches.First(approach => approach.Name == "Distributed Tracing Performance").Id },
                    //                                  new Approach() {Id =_context.approaches.First(approach => approach.Name == "Distributed Tracing User").Id },
                    //                                  new Approach() {Id =_context.approaches.First(approach => approach.Name == "Distributed Tracing Error").Id }}
                },
                new Tool()
                {
                    Name = "SkyWalking",
                    Description = "Distributed Tracing",
                    //Approaches = new List<Approach> { new Approach() {Id =_context.approaches.First(approach => approach.Name == "Distributed Tracing Performance").Id },
                    //                                  new Approach() {Id =_context.approaches.First(approach => approach.Name == "Distributed Tracing User").Id },
                    //                                  new Approach() {Id =_context.approaches.First(approach => approach.Name == "Distributed Tracing Error").Id }}
                },
            };
        }

        private List<ApproachTool> GetApproachTools()
        {
            return new List<ApproachTool>
            {
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "Error Logs").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Logstash").Id,
                    ConfigurationDifficulty = 2,
                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "Error Logs").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Grafana Loki").Id,
                    ConfigurationDifficulty = 3,
                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "Alert System").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "prometheus").Id,
                    ConfigurationDifficulty = 2,
                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "Network Traffic Performance").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "Network Traffic Security").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "Network Traffic Scalability").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "OS Metrics Scalability").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "OS Metrics Capacity").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "Health checks").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Netdata").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "OS Metrics Scalability").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Netdata").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "OS Metrics Capacity").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Netdata").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "Distributed Tracing Performance").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Jaeger").Id,
                    ConfigurationDifficulty = 3,
                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "Distributed Tracing User").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Jaeger").Id,
                    ConfigurationDifficulty = 3,
                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "Distributed Tracing Error").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Jaeger").Id,
                    ConfigurationDifficulty = 3,
                },
                                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "Distributed Tracing Performance").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "SkyWalking").Id,
                    ConfigurationDifficulty = 3,
                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "Distributed Tracing User").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "SkyWalking").Id,
                    ConfigurationDifficulty = 3,
                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(approach => approach.Name == "Distributed Tracing Error").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "SkyWalking").Id,
                    ConfigurationDifficulty = 3,
                }
            };
        }
    }
}
