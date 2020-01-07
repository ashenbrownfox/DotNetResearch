using System;
using System.Collections.Generic;
using System.Text;

namespace DeepLearning_ImageClassification_Binary
{
    class ModelOutput
    {
        public string ImagePath { get; set; }

        public string Label { get; set; }

        public string PredictedLabel { get; set; }
    }
}
