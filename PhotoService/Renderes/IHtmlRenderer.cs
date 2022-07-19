namespace PhotoService.Renderes
{
    public interface IHtmlRenderer
    {
        Task<string> RenderEmail<T>(T model);
    }
}
