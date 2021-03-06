    foreach (EA.Connector conn in element.Connectors) {
        EA.Element newNote = Package.Elements.AddNew("MyNote", "Note");
        newNote.Subtype = 1;
        newNote.Notes = "Some string";
        newNote.Update();
        repository.Execute("update t_object set PDATA4='idref=" + conn.ConnectorID + ";' " +
          where Object_ID=" + newNote.ElementID);
        //position calculation is left out here
        EA.DiagramObject k = diagram.DiagramObjects.AddNew(position, "");
        k.ElementID = newNote.ElementID;
        k.Sequence = 9;
        k.Update();
    }
