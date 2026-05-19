using System.Collections.Generic;
using _Project.Develop.Runtime.Meta.Features;
using _Project.Develop.Runtime.Meta.Features.OutcomesGame;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.OutcomesCounter
{
    public class OutcomesCounterPresenter : IPresenter
    {
        private readonly OutcomesCounterService _outcomesCounterService;
        private readonly ProjectPresentsFactory _presentsFactory;
        private readonly ViewsFactory _viewsFactory;

        private readonly TextAndTextListView _view;

        private readonly List<OutcomesPresenter> _outcomesPresenters = new();

        public OutcomesCounterPresenter(
            OutcomesCounterService outcomesCounterService,
            ProjectPresentsFactory presentsFactory,
            ViewsFactory viewsFactory,
            TextAndTextListView view)
        {
            _outcomesCounterService = outcomesCounterService;
            _presentsFactory = presentsFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        public void Initialize()
        {
            foreach (OutcomesType outcomesType in _outcomesCounterService.AvailableOutcomes)
            {
                TextAndTextView outcomesView = _viewsFactory.Create<TextAndTextView>(ViewIDs.OutcomesView);
                
                _view.Add(outcomesView);
                
                OutcomesPresenter outcomesPresenter = _presentsFactory.CreateOutcomesPresenter(
                    _outcomesCounterService.GetOutcomes(outcomesType),
                    outcomesType,
                    outcomesView);
                
                outcomesPresenter.Initialize();
                _outcomesPresenters.Add(outcomesPresenter);
            }
        }

        public void Dispose()
        {
            foreach (OutcomesPresenter outcomesPresenter in _outcomesPresenters)
            {
                _view.Remove(outcomesPresenter.View);
                _viewsFactory.Release(outcomesPresenter.View);
                outcomesPresenter.Dispose();
            }
            
            _outcomesPresenters.Clear();
        }
    }
}