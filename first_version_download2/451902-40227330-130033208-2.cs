    namespace Accord.MachineLearning.DecisionTrees
    {
      using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Text;
      using System.Threading.Tasks;
      using System.Data;
      using System.Runtime.Serialization;
      using System.Runtime.Serialization.Formatters.Binary;
      using System.IO;
      using Accord.Statistics.Filters;
      using Accord.Math;
      using AForge;
      using Accord.Statistics;
      using System.Threading;
    /// <summary>
    ///   Random Forest.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    ///   Represents a random forest of <see cref="DecisionTree"/>s. For 
    ///   sample usage and example of learning, please see the documentation
    ///   page for <see cref="RandomForestLearning"/>.</para>
    /// </remarks>
    /// 
    /// <seealso cref="DecisionTree"/>
    /// <seealso cref="RandomForestLearning"/>
    /// 
    [Serializable]
    public class RandomForest : MulticlassClassifierBase, IParallel
    {
        private DecisionTree[] trees;
        **[NonSerialized]
        private ParallelOptions parallelOptions;**
        /// <summary>
        ///   Gets the trees in the random forest.
        /// </summary>
        /// 
        public DecisionTree[] Trees
        {
            get { return trees; }
        }
        /// <summary>
        ///   Gets the number of classes that can be recognized
        ///   by this random forest.
        /// </summary>
        /// 
        [Obsolete("Please use NumberOfOutputs instead.")]
        public int Classes { get { return NumberOfOutputs; } }
        /// <summary>
        ///   Gets or sets the parallelization options for this algorithm.
        /// </summary>
        ///
        **public ParallelOptions ParallelOptions { get { return parallelOptions; } set { parallelOptions = value; } }**
        /// <summary>
        /// Gets or sets a cancellation token that can be used
        /// to cancel the algorithm while it is running.
        /// </summary>
        /// 
        public CancellationToken Token
        {
            get { return ParallelOptions.CancellationToken; }
            set { ParallelOptions.CancellationToken = value; }
        }
        /// <summary>
        ///   Creates a new random forest.
        /// </summary>
        /// 
        /// <param name="trees">The number of trees in the forest.</param>
        /// <param name="classes">The number of classes in the classification problem.</param>
        /// 
        public RandomForest(int trees, int classes)
        {
            this.trees = new DecisionTree[trees];
            this.NumberOfOutputs = classes;
            this.ParallelOptions = new ParallelOptions();
        }
        /// <summary>
        ///   Computes the decision output for a given input vector.
        /// </summary>
        /// 
        /// <param name="data">The input vector.</param>
        /// 
        /// <returns>The forest decision for the given vector.</returns>
        /// 
        [Obsolete("Please use Decide() instead.")]
        public int Compute(double[] data)
        {
            return Decide(data);
        }
        /// <summary>
        /// Computes a class-label decision for a given <paramref name="input" />.
        /// </summary>
        /// <param name="input">The input vector that should be classified into
        /// one of the <see cref="ITransform.NumberOfOutputs" /> possible classes.</param>
        /// <returns>A class-label that best described <paramref name="input" /> according
        /// to this classifier.</returns>
        public override int Decide(double[] input)
        {
            int[] responses = new int[NumberOfOutputs];
            Parallel.For(0, trees.Length, ParallelOptions, i =>
            {
                int j = trees[i].Decide(input);
                Interlocked.Increment(ref responses[j]);
            });
            return responses.ArgMax();
        }
       [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            this.ParallelOptions = new ParallelOptions();
        }
    }
    }
