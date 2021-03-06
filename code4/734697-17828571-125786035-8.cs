            <ControlTemplate x:Key="ValidationToolTipTemplate">
            <Grid x:Name="Root" Margin="5,0" RenderTransformOrigin="0,0" Opacity="0">
                <Grid.RenderTransform>
                    <TranslateTransform x:Name="xform" X="-25"/>
                </Grid.RenderTransform>
                <VisualStateManager.VisualStateGroups>
                    <VisualStateGroup Name="OpenStates">
                        <VisualStateGroup.Transitions>
                            <VisualTransition GeneratedDuration="0"/>
                            <VisualTransition To="Open" GeneratedDuration="0:0:0.2">
                                <Storyboard>
                                    <DoubleAnimation Storyboard.TargetName="xform" Storyboard.TargetProperty="X" To="0" Duration="0:0:0.2">
                                        <DoubleAnimation.EasingFunction>
                                            <BackEase Amplitude=".3" EasingMode="EaseOut"/>
                                        </DoubleAnimation.EasingFunction>
                                    </DoubleAnimation>
                                    <DoubleAnimation Storyboard.TargetName="Root" Storyboard.TargetProperty="Opacity" To="1" Duration="0:0:0.2"/>
                                </Storyboard>
                            </VisualTransition>
                        </VisualStateGroup.Transitions>
                        <VisualState x:Name="Closed">
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetName="Root" Storyboard.TargetProperty="Opacity" To="0" Duration="0"/>
                            </Storyboard>
                        </VisualState>
                        <VisualState x:Name="Open">
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetName="xform" Storyboard.TargetProperty="X" To="0" Duration="0"/>
                                <DoubleAnimation Storyboard.TargetName="Root" Storyboard.TargetProperty="Opacity" To="1" Duration="0"/>
                            </Storyboard>
                        </VisualState>
                    </VisualStateGroup>
                </VisualStateManager.VisualStateGroups>
                <Border Margin="4,4,-4,-4" Background="#052A2E31" CornerRadius="5"/>
                <Border Margin="3,3,-3,-3" Background="#152A2E31" CornerRadius="4"/>
                <Border Margin="2,2,-2,-2" Background="#252A2E31" CornerRadius="3"/>
                <Border Margin="1,1,-1,-1" Background="#352A2E31" CornerRadius="2"/>
                <Border Background="#FFDC000C" CornerRadius="2"/>
                <Border CornerRadius="2">
                    <TextBlock 
                  UseLayoutRounding="false" 
                  Foreground="White" Margin="8,4,8,4" MaxWidth="250" TextWrapping="Wrap" Text="{Binding (Validation.Errors)[0].ErrorContent}"/>
                </Border>
            </Grid>
        </ControlTemplate>
        <Style TargetType="PasswordBox">
            <Setter Property="BorderThickness" Value="1" />
            <Setter Property="Background" Value="#FFFFFFFF" />
            <Setter Property="Foreground" Value="#FF000000" />
            <Setter Property="Padding" Value="2" />
            <Setter Property="BorderBrush">
                <Setter.Value>
                    <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
                        <GradientStop Color="#FFA3AEB9" Offset="0"/>
                        <GradientStop Color="#FF8399A9" Offset="0.375"/>
                        <GradientStop Color="#FF718597" Offset="0.375"/>
                        <GradientStop Color="#FF617584" Offset="1"/>
                    </LinearGradientBrush>
                </Setter.Value>
            </Setter>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="PasswordBox">
                        <Grid x:Name="RootElement">
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualState x:Name="Normal" />
                                    <VisualState x:Name="MouseOver">
                                        <Storyboard>
                                            <ColorAnimation Storyboard.TargetName="MouseOverBorder" Storyboard.TargetProperty="(Border.BorderBrush).(SolidColorBrush.Color)" To="#FF99C1E2" Duration="0"/>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Disabled">
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetName="DisabledVisualElement" Storyboard.TargetProperty="Opacity" To="1" Duration="0"/>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="FocusStates">
                                    <VisualState x:Name="Focused">
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetName="FocusVisualElement" Storyboard.TargetProperty="Opacity" To="1" Duration="0"/>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Unfocused">
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetName="FocusVisualElement" Storyboard.TargetProperty="Opacity" To="0" Duration="0"/>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="ValidationStates">
                                    <VisualState x:Name="Valid"/>
                                    <VisualState x:Name="InvalidUnfocused">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ValidationErrorElement" Storyboard.TargetProperty="Visibility">
                                                <DiscreteObjectKeyFrame KeyTime="0" >
                                                    <DiscreteObjectKeyFrame.Value>
                                                        <Visibility>Visible</Visibility>
                                                    </DiscreteObjectKeyFrame.Value>
                                                </DiscreteObjectKeyFrame>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="InvalidFocused">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ValidationErrorElement" Storyboard.TargetProperty="Visibility">
                                                <DiscreteObjectKeyFrame KeyTime="0" >
                                                    <DiscreteObjectKeyFrame.Value>
                                                        <Visibility>Visible</Visibility>
                                                    </DiscreteObjectKeyFrame.Value>
                                                </DiscreteObjectKeyFrame>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="validationTooltip" Storyboard.TargetProperty="IsOpen">
                                                <DiscreteObjectKeyFrame KeyTime="0" >
                                                    <DiscreteObjectKeyFrame.Value>
                                                        <sys:Boolean>True</sys:Boolean>
                                                    </DiscreteObjectKeyFrame.Value>
                                                </DiscreteObjectKeyFrame>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <Border x:Name="Border" BorderThickness="{TemplateBinding BorderThickness}" CornerRadius="1" Opacity="1" Background="{TemplateBinding Background}" BorderBrush="{TemplateBinding BorderBrush}">
                                <Border x:Name="MouseOverBorder" BorderThickness="1" BorderBrush="Transparent">
                                    <Border x:Name="ContentElement" Margin="{TemplateBinding Padding}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                                </Border>
                            </Border>
                            <Border x:Name="DisabledVisualElement" Background="#A5F7F7F7" BorderBrush="#A5F7F7F7" BorderThickness="{TemplateBinding BorderThickness}" Opacity="0" IsHitTestVisible="False"/>
                            <Border x:Name="FocusVisualElement" BorderBrush="#FF6DBDD1" BorderThickness="{TemplateBinding BorderThickness}" Margin="1" Opacity="0" IsHitTestVisible="False"/>
                            <Border x:Name="ValidationErrorElement" BorderThickness="1" CornerRadius="1" BorderBrush="#FFDB000C" Visibility="Collapsed">
                                <ToolTipService.ToolTip>
                                    <ToolTip x:Name="validationTooltip" Template="{StaticResource ValidationToolTipTemplate}" Placement="Right" 
                                           PlacementTarget="{Binding RelativeSource={RelativeSource TemplatedParent}}" 
                                           DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}">
                                        <ToolTip.Triggers>
                                            <EventTrigger RoutedEvent="Canvas.Loaded">
                                                <EventTrigger.Actions>
                                                    <BeginStoryboard>
                                                        <Storyboard>
                                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="validationTooltip" Storyboard.TargetProperty="IsHitTestVisible">
                                                                <DiscreteObjectKeyFrame KeyTime="0" >
                                                                    <DiscreteObjectKeyFrame.Value>
                                                                        <sys:Boolean>true</sys:Boolean>
                                                                    </DiscreteObjectKeyFrame.Value>
                                                                </DiscreteObjectKeyFrame>
                                                            </ObjectAnimationUsingKeyFrames>
                                                        </Storyboard>
                                                    </BeginStoryboard>
                                                </EventTrigger.Actions>
                                            </EventTrigger>
                                        </ToolTip.Triggers>
                                    </ToolTip>
                                </ToolTipService.ToolTip>
                                <Grid Width="12" Height="12" HorizontalAlignment="Right" Margin="1,-4,-4,0" VerticalAlignment="Top" Background="Transparent">
                                    <Path Margin="1,3,0,0" Data="M 1,0 L6,0 A 2,2 90 0 1 8,2 L8,7 z" Fill="#FFDC000C"/>
                                    <Path Margin="1,3,0,0" Data="M 0,0 L2,0 L 8,6 L8,8" Fill="#ffffff"/>
                                </Grid>
                            </Border>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
