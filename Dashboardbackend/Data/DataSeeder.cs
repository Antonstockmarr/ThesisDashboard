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
            if (!_context.Objectives.Any() && !_context.Concerns.Any() && !_context.Approaches.Any() && !_context.Tools.Any() && !_context.ApproachTools.Any())
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
                    ObjectiveId = _context.Objectives.First(objective => objective.Name == "User Experience").Id
                },
                new Concern()
                {
                    Name = "Performance",
                    Description = "desc",
                    ObjectiveId = _context.Objectives.First(objective => objective.Name == "User Experience").Id
                },
                new Concern()
                {
                    Name = "User Behaviour",
                    Description = "desc",
                    ObjectiveId = _context.Objectives.First(objective => objective.Name == "User Experience").Id
                },
                new Concern()
                {
                    Name = "Error Management",
                    Description = "desc",
                    ObjectiveId = _context.Objectives.First(objective => objective.Name == "Incident Management").Id
                },
                new Concern()
                {
                    Name = "Network Security",
                    Description = "desc",
                    ObjectiveId = _context.Objectives.First(objective => objective.Name == "Incident Management").Id
                },
                new Concern()
                {
                    Name = "Scalability",
                    Description = "desc",
                    ObjectiveId = _context.Objectives.First(objective => objective.Name == "Resource Management").Id
                },new Concern()
                {
                    Name = "Capacity Planning",
                    Description = "desc",
                    ObjectiveId = _context.Objectives.First(objective => objective.Name == "Resource Management").Id
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
                    ConcernId = _context.Concerns.First(concern => concern.Name == "Availability").Id
                },
                new Approach()
                {
                    Name = "Network Traffic Performance",
                    Description = "Monitor CPU, storage and memory usage",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.Concerns.First(concern => concern.Name == "Performance").Id
                },
                new Approach()
                {
                    Name = "Network Traffic Security",
                    Description = "Monitor network log to analyse traffic and identify malicious activity.",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.Concerns.First(concern => concern.Name == "Network Security").Id
                },
                new Approach()
                {
                    Name = "Network Traffic Scalability",
                    Description = "desc",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.Concerns.First(concern => concern.Name == "Network Security").Id
                },
                new Approach()
                {
                    Name = "Distributed Tracing Performance",
                    Description = "Track requests across services to link events and produce timelines",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.Concerns.First(concern => concern.Name == "Performance").Id
                },
                new Approach()
                {
                    Name = "Distributed Tracing User",
                    Description = "Track requests across services to link events and produce timelines",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.Concerns.First(concern => concern.Name == "User Behaviour").Id
                },
                new Approach()
                {
                    Name = "Distributed Tracing Error",
                    Description = "Track requests across services to link events and produce timelines",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.Concerns.First(concern => concern.Name == "Error Management").Id
                },
                new Approach()
                {
                    Name = "Error Logs",
                    Description = "Logs that are produced within the application. This requires source code instrumentation.",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.Concerns.First(concern => concern.Name == "Error Management").Id
                },
                new Approach()
                {
                    Name = "Alert System",
                    Description = "Send alerts to stakeholders as reaction to specific events or thresholds.",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.Concerns.First(concern => concern.Name == "Error Management").Id
                },
                new Approach()
                {
                    Name = "OS Metrics Scalability",
                    Description = "Metrics on how the services are running, like latency, throughput, etc",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.Concerns.First(concern => concern.Name == "Scalability").Id
                },
                new Approach()
                {
                    Name = "OS Metrics Capacity",
                    Description = "Metrics on how the services are running, like latency, throughput, etc",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.Concerns.First(concern => concern.Name == "Capacity Planning").Id
                }
            };
        }

        private static List<Tool> GetTools()
        {
            return new List<Tool>
            {
                new Tool()
                {
                    Name = "Logstash",
                    Description = "Logging",
                },
                new Tool()
                {
                    Name = "Grafana Loki",
                    Description = "Logging",
                },
                new Tool()
                {
                    Name = "Prometheus",
                    Description = "Metrics",
                },
                new Tool()
                {
                    Name = "Netdata",
                    Description = "Metrics",
                },
                new Tool()
                {
                    Name = "Jaeger",
                    Description = "Distributed Tracing",
                },
                new Tool()
                {
                    Name = "SkyWalking",
                    Description = "Distributed Tracing",
                },
            };
        }

        private List<ApproachTool> GetApproachTools()
        {
            return new List<ApproachTool>
            {
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "Error Logs").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "Logstash").Id,
                    ConfigurationDifficulty = 2,
                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "Error Logs").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "Grafana Loki").Id,
                    ConfigurationDifficulty = 3,
                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "Alert System").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "prometheus").Id,
                    ConfigurationDifficulty = 2,
                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "Network Traffic Performance").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "Network Traffic Security").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "Network Traffic Scalability").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "OS Metrics Scalability").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "OS Metrics Capacity").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "Health checks").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "Netdata").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "OS Metrics Scalability").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "Netdata").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "OS Metrics Capacity").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "Netdata").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "Distributed Tracing Performance").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "Jaeger").Id,
                    ConfigurationDifficulty = 3,
                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "Distributed Tracing User").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "Jaeger").Id,
                    ConfigurationDifficulty = 3,
                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "Distributed Tracing Error").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "Jaeger").Id,
                    ConfigurationDifficulty = 3,
                },
                                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "Distributed Tracing Performance").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "SkyWalking").Id,
                    ConfigurationDifficulty = 3,
                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "Distributed Tracing User").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "SkyWalking").Id,
                    ConfigurationDifficulty = 3,
                },
                new ApproachTool()
                {
                    ApproachId = _context.Approaches.First(Approach => Approach.Name == "Distributed Tracing Error").Id,
                    ToolId = _context.Tools.First(Tools => Tools.Name == "SkyWalking").Id,
                    ConfigurationDifficulty = 3,
                }
            };
        }
    }
}
