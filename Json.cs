public class AltText
{
    public string en { get; set; }
    public string? hu { get; set; }
}

public class Bio
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class BodyText
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class Button
{
    public Label label { get; set; }
    public bool emphasis { get; set; }
    public string url { get; set; }
}

public class ButtonAltText
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class Filter
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class FilterName
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class FooterGag
{
    public Text text { get; set; }
}

public class HeaderText
{
    public Name name { get; set; }
    public Bio bio { get; set; }
    public ProjectListing project_listing { get; set; }
    public Links links { get; set; }
    public OtherLang other_lang { get; set; }
}

public class InlineName
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class Label
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class LastUpdated
{
    public Text text { get; set; }
}

public class Links
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class Links8831
{
    public AltText alt_text { get; set; }
    public string img_url { get; set; }
    public string url { get; set; }
}

public class LinksNo8831
{
    public Text text { get; set; }
    public string url { get; set; }
}

public class LinksText
{
    public TopText top_text { get; set; }
    public Title1 title1 { get; set; }
    public Text1 text1 { get; set; }
    public Title2 title2 { get; set; }
    public Title3 title3 { get; set; }
    public Text3 text3 { get; set; }
    public ButtonAltText button_alt_text { get; set; }
    public Title4 title4 { get; set; }
}

public class Name
{
    public string en { get; set; }
    public string? hu { get; set; }
}

public class NoFilter
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class OtherLang
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class ProjectEntry
{
    public Name name { get; set; }
    public int id { get; set; }
    public string type { get; set; }
    public string start_date { get; set; }
    public string? end_date { get; set; }
    public string image { get; set; }
    public AltText alt_text { get; set; }
    public BodyText body_text { get; set; }
    public List<Button> buttons { get; set; }
}

public class ProjectListing
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class ProjectListingText
{
    public TopText top_text { get; set; }
    public Filter filter { get; set; }
    public NoFilter no_filter { get; set; }
}

public class ProjectType
{
    public string code_name { get; set; }
    public FilterName filter_name { get; set; }
    public InlineName inline_name { get; set; }
}

public class Root
{
    public HeaderText header_text { get; set; }
    public ProjectListingText project_listing_text { get; set; }
    public List<ProjectType> project_types { get; set; }
    public List<ProjectEntry> project_entries { get; set; }
    public LinksText links_text { get; set; }
    public List<Links8831> links_8831 { get; set; }
    public List<LinksNo8831> links_no_8831 { get; set; }
    public FooterGag footer_gag { get; set; }
    public LastUpdated last_updated { get; set; }
}

public class Text
{
    public string en { get; set; }
    public string? hu { get; set; }
}

public class Text1
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class Text3
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class Title1
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class Title2
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class Title3
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class Title4
{
    public string en { get; set; }
    public string hu { get; set; }
}

public class TopText
{
    public string en { get; set; }
    public string hu { get; set; }
}

