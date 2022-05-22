public class Art {
    public string Name {get; set;}
    public string Description {get; set;}


    public override string ToString()
    {
        return String.Format(Name, Description);
    }
}

