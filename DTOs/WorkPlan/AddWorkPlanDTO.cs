namespace Meta.IntroApp.DTOs.WorkPlan
{
    public class AddWorkPlanDTO
    {
        public string PlanName { get; set; }
        /// <summary>
        /// Syntax : yyyy-mm-dd
        /// </summary>
        public string FromDay { get; set; }
        /// <summary>
        /// Syntax : yyyy-mm-dd
        /// </summary>
        public string ToDay { get; set; }
        /// <summary>
        /// Syntax : hh:mm
        /// </summary>
        public string FirstWorkTimeStart { get; set; }
        /// <summary>
        /// Syntax : hh:mm
        /// </summary>
        public string FirstWorkTimeEnd { get; set; }
        public string SecondWorkTimeStart { get; set; }
        public string SecondWorkTimeEnd { get; set; }
        public string Notes { get; set; }
    }
}