    <Style x:Key="TextBoxStyle1" TargetType="TextBox">
        <Setter Property="MinWidth" Value="{ThemeResource TextControlThemeMinWidth}"/>
        <Setter Property="MinHeight" Value="{ThemeResource TextControlThemeMinHeight}"/>
        <Setter Property="Foreground" Value="{ThemeResource TextControlForeground}"/>
        <Setter Property="Background" Value="{ThemeResource TextControlBackground}"/>
        <Setter Property="BorderBrush" Value="{ThemeResource TextControlBorderBrush}"/>
        <Setter Property="SelectionHighlightColor" Value="{ThemeResource TextControlSelectionHighlightColor}"/>
        <Setter Property="BorderThickness" Value="{ThemeResource TextControlBorderThemeThickness}"/>
        <Setter Property="FontFamily" Value="{ThemeResource ContentControlThemeFontFamily}"/>
        <Setter Property="FontSize" Value="{ThemeResource ControlContentThemeFontSize}"/>
        <Setter Property="ScrollViewer.HorizontalScrollMode" Value="Auto"/>
        <Setter Property="ScrollViewer.VerticalScrollMode" Value="Auto"/>
        <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Hidden"/>
        <Setter Property="ScrollViewer.VerticalScrollBarVisibility" Value="Hidden"/>
        <Setter Property="ScrollViewer.IsDeferredScrollingEnabled" Value="False"/>
        <Setter Property="Padding" Value="{ThemeResource TextControlThemePadding}"/>
        <Setter Property="UseSystemFocusVisuals" Value="{ThemeResource IsApplicationFocusVisualKindReveal}"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="TextBox">
                    <Grid>
                        <Grid.Resources>
                            <Style x:Name="DeleteStyle" TargetType="Button">
                                <Setter Property="Template">
                                    <Setter.Value>
                                        <ControlTemplate TargetType="Button">
                                            <Grid x:Name="ButtonLayoutGrid" Background="{ThemeResource TextControlButtonBackground}" BorderThickness="{TemplateBinding BorderThickness}" BorderBrush="{ThemeResource TextControlButtonBorderBrush}">
                                                <VisualStateManager.VisualStateGroups>
                                                            <VisualStateGroup x:Name="CommonStates">
                                                                <VisualState x:Name="Normal"/>
                                                                <VisualState x:Name="PointerOver">
                                                                    <Storyboard>
                                                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ButtonLayoutGrid" Storyboard.TargetProperty="Background">
                                                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlButtonBackgroundPointerOver}"/>
                                                                        </ObjectAnimationUsingKeyFrames>
                                                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ButtonLayoutGrid" Storyboard.TargetProperty="BorderBrush">
                                                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlButtonBorderBrushPointerOver}"/>
                                                                        </ObjectAnimationUsingKeyFrames>
                                                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="GlyphElement" Storyboard.TargetProperty="Foreground">
                                                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlButtonForegroundPointerOver}"/>
                                                                        </ObjectAnimationUsingKeyFrames>
                                                                    </Storyboard>
                                                                </VisualState>
                                                                <VisualState x:Name="Pressed">
                                                                    <Storyboard>
                                                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ButtonLayoutGrid" Storyboard.TargetProperty="Background">
                                                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlButtonBackgroundPressed}"/>
                                                                        </ObjectAnimationUsingKeyFrames>
                                                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ButtonLayoutGrid" Storyboard.TargetProperty="BorderBrush">
                                                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlButtonBorderBrushPressed}"/>
                                                                        </ObjectAnimationUsingKeyFrames>
                                                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="GlyphElement" Storyboard.TargetProperty="Foreground">
                                                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlButtonForegroundPressed}"/>
                                                                        </ObjectAnimationUsingKeyFrames>
                                                                    </Storyboard>
                                                                </VisualState>
                                                                <VisualState x:Name="Disabled">
                                                                    <Storyboard>
                                                                        <DoubleAnimation Duration="0" Storyboard.TargetName="ButtonLayoutGrid" Storyboard.TargetProperty="Opacity" To="0"/>
                                                                    </Storyboard>
                                                                </VisualState>
                                                            </VisualStateGroup>
                                                        </VisualStateManager.VisualStateGroups>
                                                <TextBlock x:Name="GlyphElement" AutomationProperties.AccessibilityView="Raw" FontStyle="Normal" FontFamily="{ThemeResource SymbolThemeFontFamily}" Foreground="{ThemeResource TextControlButtonForeground}" FontSize="12" HorizontalAlignment="Center" Text="&#xE10A;" VerticalAlignment="Center"/>
                                            </Grid>
                                        </ControlTemplate>
                                    </Setter.Value>
                                </Setter>
                            </Style>
                        </Grid.Resources>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*"/>
                            <ColumnDefinition Width="Auto"/>
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition Height="*"/>
                        </Grid.RowDefinitions>
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="CommonStates">
                                <VisualState x:Name="Disabled">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="HeaderContentPresenter" Storyboard.TargetProperty="Foreground">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlHeaderForegroundDisabled}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="BorderElement" Storyboard.TargetProperty="Background">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlBackgroundDisabled}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="BorderElement" Storyboard.TargetProperty="BorderBrush">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlBorderBrushDisabled}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentElement" Storyboard.TargetProperty="Foreground">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlForegroundDisabled}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PlaceholderTextContentPresenter" Storyboard.TargetProperty="Foreground">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{Binding PlaceholderForeground, RelativeSource={RelativeSource Mode=TemplatedParent}, TargetNullValue={ThemeResource TextControlPlaceholderForegroundDisabled}}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Normal"/>
                                <VisualState x:Name="PointerOver">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="BorderElement" Storyboard.TargetProperty="BorderBrush">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlBorderBrushPointerOver}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="BorderElement" Storyboard.TargetProperty="Background">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlBackgroundPointerOver}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PlaceholderTextContentPresenter" Storyboard.TargetProperty="Foreground">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{Binding PlaceholderForeground, RelativeSource={RelativeSource Mode=TemplatedParent}, TargetNullValue={ThemeResource TextControlPlaceholderForegroundPointerOver}}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentElement" Storyboard.TargetProperty="Foreground">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlForegroundPointerOver}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Focused">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PlaceholderTextContentPresenter" Storyboard.TargetProperty="Foreground">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{Binding PlaceholderForeground, RelativeSource={RelativeSource Mode=TemplatedParent}, TargetNullValue={ThemeResource TextControlPlaceholderForegroundFocused}}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="BorderElement" Storyboard.TargetProperty="Background">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlBackgroundFocused}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="BorderElement" Storyboard.TargetProperty="BorderBrush">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlBorderBrushFocused}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentElement" Storyboard.TargetProperty="Foreground">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlForegroundFocused}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentElement" Storyboard.TargetProperty="RequestedTheme">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="Light"/>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="ButtonStates">
                                <VisualState x:Name="ButtonVisible">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="Delete" Storyboard.TargetProperty="Visibility">
                                            <DiscreteObjectKeyFrame KeyTime="0">
                                                <DiscreteObjectKeyFrame.Value>
                                                    <Visibility>Visible</Visibility>
                                                </DiscreteObjectKeyFrame.Value>
                                            </DiscreteObjectKeyFrame>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="ButtonCollapsed"/>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <Border x:Name="BorderElement" Background="{TemplateBinding Background}" BorderThickness="{TemplateBinding BorderThickness}" BorderBrush="{TemplateBinding BorderBrush}" Grid.ColumnSpan="2" Control.IsTemplateFocusTarget="True" Grid.RowSpan="1" Grid.Row="1"/>
                        <ContentPresenter x:Name="HeaderContentPresenter" ContentTemplate="{TemplateBinding HeaderTemplate}" Content="{TemplateBinding Header}" Grid.ColumnSpan="2" FontWeight="Normal" Foreground="{ThemeResource TextControlHeaderForeground}" Margin="0,0,0,8" Grid.Row="0" TextWrapping="{TemplateBinding TextWrapping}" Visibility="Collapsed" x:DeferLoadStrategy="Lazy"/>
                        <ScrollViewer x:Name="ContentElement" AutomationProperties.AccessibilityView="Raw" HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}" IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}" IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}" IsTabStop="False" IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}" Margin="{TemplateBinding BorderThickness}" Padding="{TemplateBinding Padding}" Grid.Row="1" VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}" VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" ZoomMode="Disabled"/>
                        <TextBlock x:Name="PlaceholderTextContentPresenter" Grid.ColumnSpan="2" Foreground="{Binding PlaceholderForeground, RelativeSource={RelativeSource Mode=TemplatedParent}, TargetNullValue={ThemeResource TextControlPlaceholderForeground}}" IsHitTestVisible="False" Margin="{TemplateBinding BorderThickness}" Padding="{TemplateBinding Padding}" Grid.Row="1" Text="{TemplateBinding PlaceholderText}" TextWrapping="{TemplateBinding TextWrapping}" TextAlignment="{TemplateBinding TextAlignment}"/>
                        <Button x:Name="Delete" AutomationProperties.AccessibilityView="Raw" BorderThickness="{TemplateBinding BorderThickness}" Grid.Column="1" FontSize="{TemplateBinding FontSize}" IsTabStop="False" MinWidth="34" Margin="{ThemeResource HelperButtonThemePadding}" Grid.Row="1" Style="{StaticResource DeleteStyle}" VerticalAlignment="Stretch" Visibility="Collapsed"/>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
