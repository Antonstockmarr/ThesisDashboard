namespace Dashboardbackend.Dtos
{
    public class ApproachReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImplementationDifficulty { get; set; }
        public string MaintenanceDifficulty { get; set; }
        public int ConcernId { get; set; }
    }
}
