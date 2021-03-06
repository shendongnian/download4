    var spellData = from sbs in db.SpellBookSpells
                    where sbs.SpellBook_Id == id
                    select new SpellBookSpellDto
                    {
                        sbs.Id,
                        sbs.SpellBook_Id,
                        sbs.Spell_Id,
                        Spell = new SpellDto
                        {
                            sbs.Spell_Id,
                            sbs.Spell.Name,
                            sbs.Spell.Level,
                            sbs.Spell.Classes
                        }
                    };
