using Steema.TeeChart.Drawing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using XamControls.Models;

namespace XamControls.Utils
{
	public class Grouping<K, T> : ObservableCollection<T>
	{

		public K Key { get; private set; }

		public Grouping(K key, IEnumerable<T> items) {

				Key = Key;
				foreach(var item in items) {

						this.Items.Add(item);

				}

		}

		public T GetItem(int position) { return this.Items[position]; }
	
    }
}
