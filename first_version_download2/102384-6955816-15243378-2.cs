                break;
            case 3:
                switch (ButtonSourceClub)
                {
                    case "Manchester United":
                        App.Data.FeedList.Add("rss xml link here");
                        break;
                    default:
                        MessageBox.Show("Error");
                        break;
                }
                break; // <---- was missing
        }
