<!-- language-all: lang-c# --> 
           
        
   
     <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto" />
                    <ColumnDefinition Width="Auto"/>
                </Grid.ColumnDefinitions>
                <DataGrid Name="basketNameDataGrid" AutoGenerateColumns="False" CanUserResizeRows="False"
                          CanUserAddRows="False">
                    <DataGrid.RowStyle>
                        <Style TargetType="DataGridRow">
                            <Setter Property="Height" Value="{Binding RowHeight}"></Setter>
                        </Style>
                    </DataGrid.RowStyle>
                    <DataGrid.Columns>
                        <DataGridTemplateColumn Header="Basket">
                            <DataGridTemplateColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{Binding Name}" VerticalAlignment="Center"/>
                                </DataTemplate>
                            </DataGridTemplateColumn.CellTemplate>
                        </DataGridTemplateColumn>
                    </DataGrid.Columns>
                </DataGrid>
                <DataGrid Name="itemDataGrid" Grid.Column="1" AutoGenerateColumns="False" HeadersVisibility="Column" 
                          CanUserResizeRows="False" CanUserAddRows="False">
                    <DataGrid.RowStyle>
                        <Style TargetType="DataGridRow">
                            <Setter Property="Height" Value="20"></Setter>
                        </Style>
                    </DataGrid.RowStyle>
                    <DataGrid.Columns>
                        <DataGridTemplateColumn Header="Item Name">
                            <DataGridTemplateColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{Binding Name, Mode = OneWay}"/>
                                </DataTemplate>
                            </DataGridTemplateColumn.CellTemplate>
                            </DataGridTemplateColumn>
                        <DataGridTextColumn Header="Price" Binding="{Binding Price, Mode = OneWay}" CanUserSort="False"></DataGridTextColumn>
                    </DataGrid.Columns>
                </DataGrid>
            </Grid>
    
    <!-- end snippet -->
        
 
C# code - There are three classes to structure data.
(*Removed constructors to reduce code lines*)
   
    
<!-- language: lang-cs -->    
  
      class Item
        { 
            public Name {get;}
            public Price {set;}
         }
                
        class Basket : List<Item>
         {  
            public Name {get;}
         }   
    
        class BasketCollection : List<Basket>
         {
         }          
    
    <!-- end snippet -->
    
  Code behind in MainWindow.cs - Populate data and assign to DataGrids.   
   
    
