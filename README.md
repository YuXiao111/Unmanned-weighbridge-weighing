#无人值守地磅称重系统技术栈：

```
C#、WPF、CommunityToolkit.Mvvm、Sqlite数据库、MaterialDesign主题、硬件串口通讯

1.C#+WPF

2.MVVM模式

3.SQLite数据库

4.硬件通讯

```



##代码规范：

字段首字母小写，属性首字母大写



##组件：

```
CommunityToolkit.Mvvm	8.2.2 ，安装到所有类库

Microsoft.Extensions.DependencyInjection	8.0.0【依赖注入和控制反转】

MaterialDesignThemes	5.0.0【主题】

MaterialDesignColors	  3.0.0【主题】

MaterialDesignThemes.MahApps	1.0.0【主题】

Newtonsoft.Json 13.0.3 ，安装到所有类库
```



## 引用

```
CommunityToolkit.Mvvm

MaterialDesignColors

MaterialDesignThemes.MahApps

MaterialDesignThemes.Wpf

Microsoft.Extensions.DependencyInjection

Microsoft.Extensions.DependencyInjection.Abstractions

```



##MaterialDesign主题包的应用：

MainWindow.xaml的核心代码:

```c#
xmlns:vm="clr-namespace:Unmanned_weighbridge_weighing.ViewModels"
xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
d:DataContext="{d:DesignInstance vm:ShellViewModel}"
Background="{DynamicResource MaterialDesign.Brush.Background}"
FontFamily="Microsft YaHei"
TextElement.FontSize="16"
TextElement.FontWeight="Regular"
TextElement.Foreground="{DynamicResource MaterialDesignBody}"
```

App.xaml的引用

```c#
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!-- MahApps -->
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Themes/Light.Teal.xaml" />

                <!-- Material Design -->
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesign3.Defaults.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Teal.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Secondary/MaterialDesignColor.Lime.xaml" />

                <!-- Material Design: MahApps Compatibility -->
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Fonts.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Flyout.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
        
    </Application.Resources>
```



## 软件架构：

**UI：Unmanned weighbridge weighing：**

Views：视图，用于封装UI和UI逻辑；

ViewModels：视图模型，用于封装表示逻辑和状态；

Configure：注册

Services：服务

Interfaces：接口



Models：模型，用于封装应用的业务逻辑和数据 。



**核心层：Company.Core**



**硬件、仪表：Company.Hardware**

**本地数据库：Company.Sqlite**

Models：所有的实体

Interfaces：所有的接口

Repositories：所有表的增删改查



##Sqlite数据库相关配置：

```
1.安装EntityFramework 6.4.4，安装UI和数据库类库
2.安装sqlite.codefirst 1.7.0.34，安装UI和数据库类库
3.安装System.Data.Sqlite 1.0.118
4.创建ApplicationDbContext和User表实体
5.App.Config配置连接字符串
6.【关键】<provider invariantName="System.Data.SQLite" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.Sqlite.EF6"/>
```



事件传命令

```c#
xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
```

