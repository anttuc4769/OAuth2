namespace OAuth2._0.Models
{
    public class BaseModel
    {
        public virtual string ModelName { get; } = nameof(BaseModel);
        public bool ErrorFlag { get; set; }
        public string? Msg { get; set; }
        public Exception? Exception { get; set; }
        public string? PayloadData { get; set; }
    }
}
