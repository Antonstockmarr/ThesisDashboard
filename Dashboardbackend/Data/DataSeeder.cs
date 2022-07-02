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
                    Description = "Ensure customer requests are handled smoothly by monitoring availability and performance."
                },
                new Objective()
                {
                    Name = "Incident Management",
                    Description = "Detect errors when they occur, and efficiently track down what caused them."
                },
                new Objective()
                {
                    Name = "Resource Management",
                    Description = "See which parts of your system use the most resources, and how the usage fluctuates over time."
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
                    Description = "Check uptime of services to detect issues before they impact business",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "User Experience").Id
                },
                new Concern()
                {
                    Name = "Performance",
                    Description = "Monitor response times and detect performance bottlenecks",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "User Experience").Id
                },
                new Concern()
                {
                    Name = "Error Management",
                    Description = "Detect and store errors to perform queries and enable root cause analysis",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "Incident Management").Id
                },
                new Concern()
                {
                    Name = "Security",
                    Description = "Get alerted in case of potential security incidents",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "Incident Management").Id
                },
                new Concern()
                {
                    Name = "Scalability",
                    Description = "Collect data on the usage of CPU, memory and storage",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "Resource Management").Id
                },new Concern()
                {
                    Name = "Capacity Planning",
                    Description = "Analyse usage data to evaluate resource budget and meet resource demands",
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
                    Description = "Monitor metrics on API's like number of failed requests or average response time",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "medium",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Performance").Id
                },
                new Approach()
                {
                    Name = "Interservice Communication",
                    Description = "Track requests across services to link events and produce timelines",
                    ImplementationDifficulty = "hard",
                    MaintenanceDifficulty = "hard",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Performance").Id
                },
                new Approach()
                {
                    Name = "Error Logging",
                    Description = "Create logs to track errors or potential issues.",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "medium",
                    ConcernId = _context.concerns.First(concern => concern.Name == "Error Management").Id
                },
                new Approach()
                {
                    Name = "Error Tracing",
                    Description = "Implement distibuted tracing across services to enable root cause analysis",
                    ImplementationDifficulty = "hard",
                    MaintenanceDifficulty = "hard",
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
                    Description = "Analyse network traffic and detect suspicious behaviour",
                    ImplementationDifficulty = "medium",
                    MaintenanceDifficulty = "medium",
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
