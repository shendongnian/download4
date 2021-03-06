            Polygon polygon = new Polygon();
            polygon.Points = new System.Windows.Media.PointCollection()
        {
            new Point(446,134),
            new Point(442,134),
            new Point(444,140),
            new Point(444,140),
        };
            List<double> verticesPoints = new List<double>();
            double? firstGradient = null;
            double? gradient = null;
            double? newGradient = null;
            int noOfSides = 1;
            for (int i = 0; i < polygon.Points.Count - 1; i++)
            {
                var point1 = polygon.Points[i];
                var point2 = polygon.Points[i + 1];
                //calculate delta x and delta y between the two points
                var deltaX = point2.X - point1.X;
                var deltaY = point2.Y - point1.Y;
                if(deltaX == 0) { continue; }
                //calculate gradient
                newGradient = (deltaY / deltaX);
                if (i == 0)
                {
                    firstGradient = newGradient;
                }
                if ((gradient != newGradient) && (i != polygon.Points.Count - 1))
                {
                    noOfSides++;
                }
                else if (i == polygon.Points.Count - 1)
                {
                    if((gradient != newGradient) && (firstGradient != newGradient))
                    {
                        noOfSides++;
                    }
                }
                gradient = newGradient;
            }
