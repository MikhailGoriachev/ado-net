﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FirstLinqToSql
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TestDb")]
	public partial class TestDbDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCities(Cities instance);
    partial void UpdateCities(Cities instance);
    partial void DeleteCities(Cities instance);
    partial void InsertPeople(People instance);
    partial void UpdatePeople(People instance);
    partial void DeletePeople(People instance);
    #endregion
		
		public TestDbDataContext() : 
				base(global::FirstLinqToSql.Properties.Settings.Default.TestDbConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public TestDbDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TestDbDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TestDbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TestDbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Cities> Cities
		{
			get
			{
				return this.GetTable<Cities>();
			}
		}
		
		public System.Data.Linq.Table<People> People
		{
			get
			{
				return this.GetTable<People>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Cities")]
	public partial class Cities : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private int _Population;
		
		private EntitySet<People> _People;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPopulationChanging(int value);
    partial void OnPopulationChanged();
    #endregion
		
		public Cities()
		{
			this._People = new EntitySet<People>(new Action<People>(this.attach_People), new Action<People>(this.detach_People));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Population", DbType="Int NOT NULL")]
		public int Population
		{
			get
			{
				return this._Population;
			}
			set
			{
				if ((this._Population != value))
				{
					this.OnPopulationChanging(value);
					this.SendPropertyChanging();
					this._Population = value;
					this.SendPropertyChanged("Population");
					this.OnPopulationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Cities_People", Storage="_People", ThisKey="Id", OtherKey="IdCity")]
		public EntitySet<People> People
		{
			get
			{
				return this._People;
			}
			set
			{
				this._People.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_People(People entity)
		{
			this.SendPropertyChanging();
			entity.Cities = this;
		}
		
		private void detach_People(People entity)
		{
			this.SendPropertyChanging();
			entity.Cities = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.People")]
	public partial class People : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _SurnameNP;
		
		private int _IdCity;
		
		private int _Age;
		
		private EntityRef<Cities> _Cities;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnSurnameNPChanging(string value);
    partial void OnSurnameNPChanged();
    partial void OnIdCityChanging(int value);
    partial void OnIdCityChanged();
    partial void OnAgeChanging(int value);
    partial void OnAgeChanged();
    #endregion
		
		public People()
		{
			this._Cities = default(EntityRef<Cities>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SurnameNP", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
		public string SurnameNP
		{
			get
			{
				return this._SurnameNP;
			}
			set
			{
				if ((this._SurnameNP != value))
				{
					this.OnSurnameNPChanging(value);
					this.SendPropertyChanging();
					this._SurnameNP = value;
					this.SendPropertyChanged("SurnameNP");
					this.OnSurnameNPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdCity", DbType="Int NOT NULL")]
		public int IdCity
		{
			get
			{
				return this._IdCity;
			}
			set
			{
				if ((this._IdCity != value))
				{
					if (this._Cities.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdCityChanging(value);
					this.SendPropertyChanging();
					this._IdCity = value;
					this.SendPropertyChanged("IdCity");
					this.OnIdCityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int NOT NULL")]
		public int Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this.OnAgeChanging(value);
					this.SendPropertyChanging();
					this._Age = value;
					this.SendPropertyChanged("Age");
					this.OnAgeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Cities_People", Storage="_Cities", ThisKey="IdCity", OtherKey="Id", IsForeignKey=true)]
		public Cities Cities
		{
			get
			{
				return this._Cities.Entity;
			}
			set
			{
				Cities previousValue = this._Cities.Entity;
				if (((previousValue != value) 
							|| (this._Cities.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cities.Entity = null;
						previousValue.People.Remove(this);
					}
					this._Cities.Entity = value;
					if ((value != null))
					{
						value.People.Add(this);
						this._IdCity = value.Id;
					}
					else
					{
						this._IdCity = default(int);
					}
					this.SendPropertyChanged("Cities");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
