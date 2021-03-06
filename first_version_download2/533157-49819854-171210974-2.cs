    <Expander Name="Exp" IsExpanded="{TemplateBinding TreeViewItem.IsExpanded}">
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="Expanded">
                <i:InvokeCommandAction Command="{Binding DataContext.OpenPartListCommand, RelativeSource={RelativeSource AncestorType=TreeView}}" 
                                       CommandParameter="{Binding ElementName=PartsTreeView, Path=SelectedItem}"/>
            </i:EventTrigger>
            <i:EventTrigger EventName="Collapsed">
                <i:InvokeCommandAction Command="{Binding DataContext.OpenPartListCommand, RelativeSource={RelativeSource AncestorType=TreeView}}" 
                                       CommandParameter="{Binding ElementName=PartsTreeView, Path=SelectedItem}"/>
            </i:EventTrigger>
        </i:Interaction.Triggers>
        <Expander.Header>
            <ContentPresenter ContentSource="Header" />
        </Expander.Header>
        <ItemsPresenter />
    </Expander>
