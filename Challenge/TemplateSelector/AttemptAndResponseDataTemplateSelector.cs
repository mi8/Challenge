using Challenge.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Challenge.TemplateSelector
{
    class AttemptAndResponseDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Attempt { get; set; }
        public DataTemplate BiggerOrSmaller { get; set; }
        public DataTemplate Success { get; set; }
        public DataTemplate Reset { get; set; }
        public DataTemplate Error { get; set; }

        public AttemptAndResponseDataTemplateSelector()
        {
            Attempt = new DataTemplate();
            BiggerOrSmaller = new DataTemplate();
            Success = new DataTemplate();
            Reset = new DataTemplate();
            Error = new DataTemplate();
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (((NumberFinderMessage)item).ViewType)
            {
                case NumberFinderMessage.ViewTypeEnum.NumberFinderAttempt:
                    return Attempt;
                case NumberFinderMessage.ViewTypeEnum.NumberFinderBiggerOrSmaller:
                    return BiggerOrSmaller;
                case NumberFinderMessage.ViewTypeEnum.NumberFinderSuccess:
                    return Success;
                case NumberFinderMessage.ViewTypeEnum.NumberFinderReset:
                    return Reset;
                case NumberFinderMessage.ViewTypeEnum.NumberFinderError:
                    return Error;
            }
            return Attempt;
        }
    }
}
