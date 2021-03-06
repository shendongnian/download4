            <Style TargetType="{x:Type ListView}">
                <Style.Triggers>
                    <!-- This binding needs to point to some global propery that you'll change to switch views.-->
                    <DataTrigger Binding="{Binding CountSumCondition}" Value="True">
                        <Setter Property="View">
                            <Setter.Value>
                                <GridView>
                                    <GridViewColumn Width="140" Header="Column 1" DisplayMemberBinding="{Binding Name}" />
                                    <GridViewColumn Width="140" Header="Column 2" DisplayMemberBinding="{Binding Count}" />
                                </GridView>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding CountSumCondition}" Value="False">
                        <Setter Property="View">
                            <Setter.Value>
                                <GridView>
                                    <GridViewColumn Width="140" Header="Column 1" DisplayMemberBinding="{Binding Name}" />
                                    <GridViewColumn Width="140" Header="Column 2" DisplayMemberBinding="{Binding Sum}" />
                                </GridView>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
