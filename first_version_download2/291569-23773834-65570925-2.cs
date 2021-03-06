         static Dictionary<string, Folder> GetSharedCalendarFolders(ExchangeService service, String mbMailboxname)
        {
            Dictionary<String, Folder> rtList = new System.Collections.Generic.Dictionary<string, Folder>();
            
            FolderId rfRootFolderid = new FolderId(WellKnownFolderName.Root, mbMailboxname);
            FolderView fvFolderView = new FolderView(1000);
            SearchFilter sfSearchFilter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "Common Views");
            FindFoldersResults ffoldres = service.FindFolders(rfRootFolderid, sfSearchFilter, fvFolderView);
            if (ffoldres.Folders.Count == 1)
            {
                PropertySet psPropset = new PropertySet(BasePropertySet.FirstClassProperties);
                ExtendedPropertyDefinition PidTagWlinkAddressBookEID = new ExtendedPropertyDefinition(0x6854, MapiPropertyType.Binary);
                ExtendedPropertyDefinition PidTagWlinkFolderType = new ExtendedPropertyDefinition(0x684F, MapiPropertyType.Binary);
                ExtendedPropertyDefinition PidTagWlinkGroupName = new ExtendedPropertyDefinition(0x6851, MapiPropertyType.String);
                psPropset.Add(PidTagWlinkAddressBookEID);
	            psPropset.Add(PidTagWlinkFolderType);
                ItemView iv = new ItemView(1000);
                iv.PropertySet = psPropset;
                iv.Traversal = ItemTraversal.Associated;
                SearchFilter cntSearch = new SearchFilter.IsEqualTo(PidTagWlinkGroupName, "Other Calendars");
                FindItemsResults<Item> fiResults = ffoldres.Folders[0].FindItems(cntSearch, iv);
                foreach (Item itItem in fiResults.Items)
                {
                    try
                    {
                        object GroupName = null;
                        object WlinkAddressBookEID = null;
                        if (itItem.TryGetProperty(PidTagWlinkAddressBookEID, out WlinkAddressBookEID))
                        {
                            byte[] ssStoreID = (byte[])WlinkAddressBookEID;
                            int leLegDnStart = 0;
                            String lnLegDN = "";
                            for (int ssArraynum = (ssStoreID.Length - 2); ssArraynum != 0; ssArraynum--)
                            {
                                if (ssStoreID[ssArraynum] == 0)
                                {
                                    leLegDnStart = ssArraynum;
                                    lnLegDN = System.Text.ASCIIEncoding.ASCII.GetString(ssStoreID, leLegDnStart + 1, (ssStoreID.Length - (leLegDnStart + 2)));
                                    ssArraynum = 1;
                                }
                            }
                            NameResolutionCollection ncCol = service.ResolveName(lnLegDN, ResolveNameSearchLocation.DirectoryOnly, true);
                            if (ncCol.Count > 0)
                            {
                                FolderId SharedCalendarId = new FolderId(WellKnownFolderName.Calendar, ncCol[0].Mailbox.Address);
                                Folder SharedCalendaFolder = Folder.Bind(service, SharedCalendarId);
                                rtList.Add(ncCol[0].Mailbox.Address, SharedCalendaFolder);
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
            return rtList;
        }
