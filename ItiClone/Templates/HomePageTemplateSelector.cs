using ItiClone.ContentViews;
using ItiClone.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItiClone.Templates
{
    public class HomePageTemplateSelector : DataTemplateSelector, IMarkupExtension
    {
        private readonly DataTemplate _transaction;
        private readonly DataTemplate _connection;
        private readonly DataTemplate _cards;
        private readonly DataTemplate _recommendations;

        public HomePageTemplateSelector()
        {
            _transaction = new DataTemplate(typeof(TransactionContentView));
            _connection = new DataTemplate(typeof(ConnectionContentView));
            _cards = new DataTemplate(typeof(CardsContentView));
            _recommendations = new DataTemplate(typeof(RecommendationContentView));
        }

        public object ProvideValue(IServiceProvider serviceProvider) => this;

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Resume resume)
            {
                if (resume.ResumeType == ResumeType.Transactions)
                    return _transaction;
                else if (resume.ResumeType == ResumeType.Connections)
                    return _connection;
                else if (resume.ResumeType == ResumeType.Cards)
                    return _cards;
                else if (resume.ResumeType == ResumeType.Recommendation)
                    return _recommendations;
                else
                    return new DataTemplate(typeof(ContentView));
            }

            return new DataTemplate(typeof(ContentView));
        }
    }
}