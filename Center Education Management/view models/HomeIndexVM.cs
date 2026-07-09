namespace Center_Education_Management.view_models
{
    public class IconTextItem
    {
        public string Icon { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class StatItem
    {
        public string Icon { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
    }

    public class RoleItem
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class FaqItem
    {
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }

    public class TeamMemberItem
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }

    public class HomeIndexVM
    {
        public List<StatItem> Stats { get; set; } = new();
        public List<IconTextItem> Features { get; set; } = new();
        public List<IconTextItem> Steps { get; set; } = new();
        public List<RoleItem> ForWho { get; set; } = new();
        public List<IconTextItem> Why { get; set; } = new();
        public List<FaqItem> Faqs { get; set; } = new();
        public List<TeamMemberItem> Team { get; set; } = new();
    }
}
