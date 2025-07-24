public class Button
{
    public Label label { get; set; }
    public bool emphasis { get; set; }
    public string url { get; set; }
}

public class HeaderText
{
    public Name name { get; set; }
    public Bio bio { get; set; }
    public ProjectListing project_listing { get; set; }
    public Links links { get; set; }
    public OtherLang other_lang { get; set; }
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

public class ProjectEntry
{
    public Name name { get; set; }
    public int id { get; set; }
    public string type { get; set; }
    public string start_date { get; set; }
    public string end_date { get; set; }
    public string image { get; set; }
    public string imageFull { get; set; }
    public AltText alt_text { get; set; }
    public BodyText body_text { get; set; }
    public List<Button> buttons { get; set; }
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

public class RootStrings
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

    public string GetInlineName(string codeName, string locale)
    {
        for (int i = 0; i < project_types.Count; i++)
        {
            if (codeName == project_types[i].code_name) return project_types[i].inline_name.text.Get(locale);
        }
        return "ERROR!";
    }
}

public class Text
{
    public string en { get; set; }
    public string hu { get; set; }

    public string Get(string locale)
    {
        if (locale == "hu" && hu != null) return hu;
        return en;
    }
}

public class JustText
{
    public Text text { get; set; }
}

public class Text1 : JustText { }

public class Text3 : JustText { }

public class Title1 : JustText { }

public class Title2 : JustText { }

public class Title3 : JustText { }

public class Title4 : JustText { }

public class TopText : JustText { }

public class AltText : JustText { }

public class Bio : JustText { }

public class BodyText : JustText { }

public class ButtonAltText : JustText { }

public class Filter : JustText { }

public class FilterName : JustText { }

public class FooterGag : JustText { }

public class InlineName : JustText { }

public class Label : JustText { }

public class LastUpdated : JustText { }

public class Links : JustText { }

public class Name : JustText { }

public class NoFilter : JustText { }

public class OtherLang : JustText { }

public class ProjectListing : JustText { }