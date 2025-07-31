namespace _ROOT.UI.PatternBases.MVP
{
    public interface IBaseView<TData> 
    {
        void UpdateView(TData data);
    }
}