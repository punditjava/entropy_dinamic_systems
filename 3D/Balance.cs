using System;

namespace osiptest
{
    class Balance
    {
        private double lambda;
        private readonly SparseMatrixBal M;

        public Balance(SparseMatrixBal M, double lambda)
        {
            this.M = M;
            this.lambda = lambda;
        }

        public System.Collections.Generic.Dictionary<int, double> balancing()
        {

            double last_value;
            double this_value;
            M.normilize();
            int s = 0;
            do
            {
                M.normilize();
                for (int i = 0; i < M.columnCount(); i++)
                {
                    M.transform(i);
                }
                last_value = M.get_all();
                //this_value = M.get_all();
                s++;
            } while (Math.Abs(last_value - 1) > lambda);
            Console.WriteLine("b " + s);
            return M.get_result();
        }
        public double get_M()
        {
            return M.entropy;
        }
    }
}
