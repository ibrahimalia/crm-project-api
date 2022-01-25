namespace Meta.IntroApp.DTOs.WorkPlan
{
    public class WorkPlanDTO
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public string FromDay { get; set; }
        public string ToDay { get; set; }
        public string FirstWorkTimeStart { get; set; }
        public string FirstWorkTimeEnd { get; set; }
        public string SecondWorkTimeStart { get; set; }
        public string SecondWorkTimeEnd { get; set; }
        public string Notes { get; set; }
    }
}