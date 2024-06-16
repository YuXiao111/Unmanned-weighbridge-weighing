C#、WPF、CommunityToolkit.Mvvm、Sqlite数据库、MaterialDesign主题、硬件串口通讯

1.C#+WPF

2.MVVM模式

3.SQLite数据库

4.硬件通讯



MainWindow.xaml的核心代码:

```
xmlns:vm="clr-namespace:Unmanned_weighbridge_weighing.ViewModels"
xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
d:DataContext="{d:DesignInstance vm:ShellViewModel}"
Background="{DynamicResource MaterialDesign.Brush.Background}"
FontFamily="Microsft YaHei"
TextElement.FontSize="16"
TextElement.FontWeight="Regular"
TextElement.Foreground="{DynamicResource MaterialDesignBody}"
```

核心层：Company.Core

硬件、仪表：Company.Hardware

本地数据库：Company.Sqlite



**Company.Sqlite**

Sqlite数据库相关配置：

```
1.安装EntityFramework 6.4.4
2.安装sqlite.codefirst 1.7.0.34
3.安装System.Data.Sqlite 1.0.118
4.创建ApplicationDbContext和User表实体
5.App.Config配置连接字符串
6.【关键】<provider invariantName="System.Data.SQLite" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.Sqlite.EF6"/>
```

实体：Models

接口：Interfaces

表的操作：Repositories



**Unmanned weighbridge weighing**

Services：服务层

