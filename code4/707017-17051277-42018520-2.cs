	public class ConcatConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			List<IEnumerable> enumerables = new List<IEnumerable>();
			foreach (object obj in values)
			{
				IEnumerable temp = obj as IEnumerable;
				if (temp == null) throw new ArgumentException();
				enumerables.Add(temp);
			}
                        dynamic enDynamic = enumerables;
			return Concat(enDynamic);
		}
		private IEnumerable<T> Concat<T>(params IEnumerable<T>[] toConcat)
		{
                    return toConcat.Aggregate((a, b) => a.Concat(b));
		}
		private IEnumerable Concat(params IEnumerable[] toConcat)
		{
			ArrayList temp = new ArrayList();
			foreach (IEnumerable x in toConcat)
			{
				foreach (object n in x)
				{
					temp.Add(n);
				}
			}
			return temp;
		}
		public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
