namespace _ROOT.UI.PatternBases.MVP
{
    public abstract class BasePresenter<TModel, TView, TData> 
        where TModel : BaseModel<TData>
        where TView : class
        where TData : class
    {
        protected readonly TModel _model;
        protected readonly TView _view;

        protected BasePresenter(TModel model, TView view)
        {
            _model = model;
            _view = view;
        
            _model.OnDataLoaded += OnDataLoaded;
        }

        protected abstract void OnDataLoaded(TData data);

        public void AssignData() => 
            _model.LoadData();
    }
}