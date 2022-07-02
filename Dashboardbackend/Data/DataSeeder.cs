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
            if (NotSeeded())
            {
                Console.WriteLine("Populating database...");
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
                _context.AddRange(GetSetupConfigurations());
                await _context.SaveChangesAsync();
                _context.AddRange(GetConfigurationPackages());
                await _context.SaveChangesAsync();
            }
        }

        private bool NotSeeded()
        {
            return !_context.objectives.Any()
                && !_context.concerns.Any()
                && !_context.approaches.Any()
                && !_context.tools.Any()
                && !_context.approachTools.Any()
                && !_context.configurations.Any()
                && !_context.configurationPackages.Any();
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
                    Name = "Error Management",
                    Description = "desc",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "Incident Management").Id
                },
                new Concern()
                {
                    Name = "Security",
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
                    Name = "Health Checks",
                    Description = "Periodically ping services to see if they are up",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Availability").Id
                },
                new Approach()
                {
                    Name = "API Performance",
                    Description = "Track requests across services to link events and produce timelines",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Performance").Id
                },
                new Approach()
                {
                    Name = "Interservice Communication",
                    Description = "Track requests across services to link events and produce timelines",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Performance").Id
                },
                new Approach()
                {
                    Name = "Error Tracing",
                    Description = "Logs that are produced within the application. This requires source code instrumentation.",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Error Management").Id
                },
                new Approach()
                {
                    Name = "Error Logging",
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
                    Name = "Network Traffic",
                    Description = "Monitor CPU, storage and memory usage",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Security").Id
                },
                new Approach()
                {
                    Name = "OS Metrics",
                    Description = "Metrics on how the services are running, like latency, throughput, etc",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Scalability").Id
                },
                new Approach()
                {
                    Name = "OS Metrics",
                    Description = "Metrics on how the services are running, like latency, throughput, etc",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Capacity Planning").Id
                }
            };
        }

        private static List<Tool> GetTools()
        {
            return new List<Tool>
            {
                new Tool()
                {
                    Name = "ELK",
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
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "Error Logging").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "ELK").Id,
                    ConfigurationDifficulty = 2,
                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "Error Logging").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Grafana Loki").Id,
                    ConfigurationDifficulty = 3,
                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "Alert System").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Prometheus").Id,
                    ConfigurationDifficulty = 2,
                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "API Performance").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "Network Traffic").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "OS Metrics").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "OS Metrics").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "Health Checks").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Prometheus").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "OS Metrics").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Netdata").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "OS Metrics").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Netdata").Id,
                    ConfigurationDifficulty = 3,

                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "Interservice Communication").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Jaeger").Id,
                    ConfigurationDifficulty = 3,
                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "Error Tracing").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "Jaeger").Id,
                    ConfigurationDifficulty = 3,
                },
                                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "Interservice Communication").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "SkyWalking").Id,
                    ConfigurationDifficulty = 3,
                },
                new ApproachTool()
                {
                    ApproachId = _context.approaches.First(Approach => Approach.Name == "Error Tracing").Id,
                    ToolId = _context.tools.First(tools => tools.Name == "SkyWalking").Id,
                    ConfigurationDifficulty = 3,
                }
            };
        }

        private List<Configuration> GetSetupConfigurations()
        {
            return new List<Configuration>
            {
                new Configuration
                {
                    Image = "https://configurationfiles.blob.core.windows.net/images/prometheus-healthchecks-jaeger-tracing.png",
                    SetupFiles = "https://configurationfiles.blob.core.windows.net/configuration-files/prometheus-healthchecks-jaeger-tracing.zip",
                    Description = "prometheus-healthcheacks-jaeger-tracing",
                    Markdown = "https://configurationfiles.blob.core.windows.net/markdown-files/setupDescription.md"
                },
                new Configuration
                {
                    Image = "https://configurationfiles.blob.core.windows.net/images/logstash-errorlogs.png",
                    SetupFiles = "https://configurationfiles.blob.core.windows.net/configuration-files/logstash-errorlogs.zip",
                    Description = "ELK-errorlogs",
                    Markdown = "https://configurationfiles.blob.core.windows.net/markdown-files/setupDescription.md"
                },
            };
        }

        private List<ConfigurationPackage> GetConfigurationPackages()
        {
            return new List<ConfigurationPackage>
            {
                new ConfigurationPackage
                {
                    ApproachToolId = _context.approachTools.First(approachTool =>
                        _context.tools.Any(tool => (tool.Id == approachTool.ToolId)
                                                && (tool.Name == "Prometheus"))
                        && _context.approaches.Any(approach => (approach.Id == approachTool.ApproachId)
                                                && (approach.Name == "Health Checks"))
                        ).Id,
                    ConfigurationId = _context.configurations.First(setupConfiguration =>
                            setupConfiguration.Description == "prometheus-healthcheacks-jaeger-tracing").Id
                },
                new ConfigurationPackage
                {
                    ApproachToolId = _context.approachTools.First(approachTool =>
                        _context.tools.Any(tool => (tool.Id == approachTool.ToolId)
                                                && (tool.Name == "Jaeger"))
                        && _context.approaches.Any(approach => (approach.Id == approachTool.ApproachId)
                                                && (approach.Name == "Error Tracing"))
                        ).Id,
                    ConfigurationId = _context.configurations.First(setupConfiguration =>
                            setupConfiguration.Description == "prometheus-healthcheacks-jaeger-tracing").Id
                },
                new ConfigurationPackage
                {
                    ApproachToolId = _context.approachTools.First(approachTool =>
                        _context.tools.Any(tool => (tool.Id == approachTool.ToolId)
                                                && (tool.Name == "ELK"))
                        && _context.approaches.Any(approach => (approach.Id == approachTool.ApproachId)
                                                && (approach.Name == "Error Logging"))
                        ).Id,
                    ConfigurationId = _context.configurations.First(setupConfiguration =>
                            setupConfiguration.Description == "ELK-errorlogs").Id
                },
            };
        }

    }
}
