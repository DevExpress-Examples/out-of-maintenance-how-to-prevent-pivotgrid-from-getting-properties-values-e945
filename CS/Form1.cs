using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Q135913 {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();

			List<DataObject> fakeDataSource = new List<DataObject>();
			fakeDataSource.Add(new DataObject());
			pivotGridControl1.DataSource = new DataSourceWrapper(ReportType.Report1, fakeDataSource);
			pivotGridControl1.RetrieveFields();
			pivotGridControl2.DataSource = new DataSourceWrapper(ReportType.Report2, fakeDataSource);
			pivotGridControl2.RetrieveFields();
		}
	}

	public class DataObject {
		public string A { get { return "A"; } }
		public string B { get { return "B"; } }
	}

	public enum ReportType { Report1, Report2 }

	public class DataSourceWrapper : ITypedList, IList {
		readonly ReportType rtype;
		readonly IList dataSource;

		public DataSourceWrapper(ReportType rtype, IList dataSource) {
			this.rtype = rtype;
			this.dataSource = dataSource;
		}

		#region ITypedList Members
		PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors) {
			PropertyDescriptorCollection props = null;
			ITypedList srcTypedList = dataSource as ITypedList;
			if(srcTypedList != null)
				props = srcTypedList.GetItemProperties(listAccessors);
			if(dataSource.Count > 0)
				props = TypeDescriptor.GetProperties(dataSource[0]);
			if(props == null) 
				return null;

			List<PropertyDescriptor> res = new List<PropertyDescriptor>();
			switch(rtype) {
				case ReportType.Report1:
					res.Add(props["A"]);
					break;
				case ReportType.Report2:
					res.Add(props["B"]);
					break;
			}

			return new PropertyDescriptorCollection(res.ToArray());
		}
		string ITypedList.GetListName(PropertyDescriptor[] listAccessors) {
			return GetType().Name;
		}
		#endregion

		#region IList Members
		public int Add(object value) {
			return dataSource.Add(value);
		}
		public void Clear() {
			dataSource.Clear();
		}
		public bool Contains(object value) {
			return dataSource.Contains(value);
		}
		public int IndexOf(object value) {
			return dataSource.IndexOf(value);
		}
		public void Insert(int index, object value) {
			dataSource.Insert(index, value);
		}
		public bool IsFixedSize {
			get { return dataSource.IsFixedSize; }
		}
		public bool IsReadOnly {
			get { return dataSource.IsReadOnly; }
		}
		public void Remove(object value) {
			dataSource.Remove(value);
		}
		public void RemoveAt(int index) {
			dataSource.RemoveAt(index);
		}
		public object this[int index] {
			get {
				return dataSource[index];
			}
			set {
				dataSource[index] = value;
			}
		}
		#endregion

		#region ICollection Members
		public void CopyTo(Array array, int index) {
			dataSource.CopyTo(array, index);
		}
		public int Count {
			get { return dataSource.Count; }
		}
		public bool IsSynchronized {
			get { return dataSource.IsSynchronized; }
		}
		public object SyncRoot {
			get { return dataSource.SyncRoot; }
		}
		#endregion

		#region IEnumerable Members
		public IEnumerator GetEnumerator() {
			return dataSource.GetEnumerator();
		}
		#endregion
	}
}