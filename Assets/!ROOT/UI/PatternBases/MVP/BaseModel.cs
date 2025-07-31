using System;

namespace _ROOT.UI.PatternBases.MVP
{
    public abstract class BaseModel<TData> where TData : class
    {
        public event Action<TData> OnDataLoaded;
    
        private TData _data;
        private bool _isLoaded;

        // Явный метод загрузки данных (вызывается из Presenter)
        public void LoadData() 
        {
            if (_isLoaded) return;
        
            _data = LoadDataInternal();
            _isLoaded = true;
            OnDataLoaded?.Invoke(_data);
        }
        
        protected abstract TData LoadDataInternal();
        
        public TData GetData() => _data;
    }
}