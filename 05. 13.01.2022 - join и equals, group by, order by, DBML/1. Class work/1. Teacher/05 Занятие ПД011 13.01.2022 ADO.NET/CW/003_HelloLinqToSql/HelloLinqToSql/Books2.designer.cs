#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelloLinqToSql
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Books2")]
	public partial class Books2DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void Insertauthors(authors instance);
    partial void Updateauthors(authors instance);
    partial void Deleteauthors(authors instance);
    partial void Insertbooks(books instance);
    partial void Updatebooks(books instance);
    partial void Deletebooks(books instance);
    partial void Insertcategories(categories instance);
    partial void Updatecategories(categories instance);
    partial void Deletecategories(categories instance);
    #endregion
		
		public Books2DataContext() : 
				base(global::HelloLinqToSql.Properties.Settings.Default.Books2ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public Books2DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Books2DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Books2DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Books2DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<authors> authors
		{
			get
			{
				return this.GetTable<authors>();
			}
		}
		
		public System.Data.Linq.Table<books> books
		{
			get
			{
				return this.GetTable<books>();
			}
		}
		
		public System.Data.Linq.Table<categories> categories
		{
			get
			{
				return this.GetTable<categories>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.authors")]
	public partial class authors : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private EntitySet<books> _books;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public authors()
		{
			this._books = new EntitySet<books>(new Action<books>(this.attach_books), new Action<books>(this.detach_books));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="authors_books", Storage="_books", ThisKey="id", OtherKey="idAuthor")]
		public EntitySet<books> books
		{
			get
			{
				return this._books;
			}
			set
			{
				this._books.Assign(value);
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
		
		private void attach_books(books entity)
		{
			this.SendPropertyChanging();
			entity.authors = this;
		}
		
		private void detach_books(books entity)
		{
			this.SendPropertyChanging();
			entity.authors = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.books")]
	public partial class books : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _idAuthor;
		
		private System.Nullable<int> _idCategory;
		
		private string _title;
		
		private int _year;
		
		private int _price;
		
		private int _amount;
		
		private EntityRef<authors> _authors;
		
		private EntityRef<categories> _categories;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnidAuthorChanging(int value);
    partial void OnidAuthorChanged();
    partial void OnidCategoryChanging(System.Nullable<int> value);
    partial void OnidCategoryChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    partial void OnyearChanging(int value);
    partial void OnyearChanged();
    partial void OnpriceChanging(int value);
    partial void OnpriceChanged();
    partial void OnamountChanging(int value);
    partial void OnamountChanged();
    #endregion
		
		public books()
		{
			this._authors = default(EntityRef<authors>);
			this._categories = default(EntityRef<categories>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idAuthor", DbType="Int NOT NULL")]
		public int idAuthor
		{
			get
			{
				return this._idAuthor;
			}
			set
			{
				if ((this._idAuthor != value))
				{
					if (this._authors.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidAuthorChanging(value);
					this.SendPropertyChanging();
					this._idAuthor = value;
					this.SendPropertyChanged("idAuthor");
					this.OnidAuthorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCategory", DbType="Int")]
		public System.Nullable<int> idCategory
		{
			get
			{
				return this._idCategory;
			}
			set
			{
				if ((this._idCategory != value))
				{
					if (this._categories.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidCategoryChanging(value);
					this.SendPropertyChanging();
					this._idCategory = value;
					this.SendPropertyChanged("idCategory");
					this.OnidCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_year", DbType="Int NOT NULL")]
		public int year
		{
			get
			{
				return this._year;
			}
			set
			{
				if ((this._year != value))
				{
					this.OnyearChanging(value);
					this.SendPropertyChanging();
					this._year = value;
					this.SendPropertyChanged("year");
					this.OnyearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_price", DbType="Int NOT NULL")]
		public int price
		{
			get
			{
				return this._price;
			}
			set
			{
				if ((this._price != value))
				{
					this.OnpriceChanging(value);
					this.SendPropertyChanging();
					this._price = value;
					this.SendPropertyChanged("price");
					this.OnpriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_amount", DbType="Int NOT NULL")]
		public int amount
		{
			get
			{
				return this._amount;
			}
			set
			{
				if ((this._amount != value))
				{
					this.OnamountChanging(value);
					this.SendPropertyChanging();
					this._amount = value;
					this.SendPropertyChanged("amount");
					this.OnamountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="authors_books", Storage="_authors", ThisKey="idAuthor", OtherKey="id", IsForeignKey=true)]
		public authors authors
		{
			get
			{
				return this._authors.Entity;
			}
			set
			{
				authors previousValue = this._authors.Entity;
				if (((previousValue != value) 
							|| (this._authors.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._authors.Entity = null;
						previousValue.books.Remove(this);
					}
					this._authors.Entity = value;
					if ((value != null))
					{
						value.books.Add(this);
						this._idAuthor = value.id;
					}
					else
					{
						this._idAuthor = default(int);
					}
					this.SendPropertyChanged("authors");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="categories_books", Storage="_categories", ThisKey="idCategory", OtherKey="id", IsForeignKey=true)]
		public categories categories
		{
			get
			{
				return this._categories.Entity;
			}
			set
			{
				categories previousValue = this._categories.Entity;
				if (((previousValue != value) 
							|| (this._categories.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._categories.Entity = null;
						previousValue.books.Remove(this);
					}
					this._categories.Entity = value;
					if ((value != null))
					{
						value.books.Add(this);
						this._idCategory = value.id;
					}
					else
					{
						this._idCategory = default(Nullable<int>);
					}
					this.SendPropertyChanged("categories");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.categories")]
	public partial class categories : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _category;
		
		private EntitySet<books> _books;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OncategoryChanging(string value);
    partial void OncategoryChanged();
    #endregion
		
		public categories()
		{
			this._books = new EntitySet<books>(new Action<books>(this.attach_books), new Action<books>(this.detach_books));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_category", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string category
		{
			get
			{
				return this._category;
			}
			set
			{
				if ((this._category != value))
				{
					this.OncategoryChanging(value);
					this.SendPropertyChanging();
					this._category = value;
					this.SendPropertyChanged("category");
					this.OncategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="categories_books", Storage="_books", ThisKey="id", OtherKey="idCategory")]
		public EntitySet<books> books
		{
			get
			{
				return this._books;
			}
			set
			{
				this._books.Assign(value);
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
		
		private void attach_books(books entity)
		{
			this.SendPropertyChanging();
			entity.categories = this;
		}
		
		private void detach_books(books entity)
		{
			this.SendPropertyChanging();
			entity.categories = null;
		}
	}
}
#pragma warning restore 1591
