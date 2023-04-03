import Dexie from "dexie";

export let db = new Dexie("BabyTracker");

db.version(2).stores({
    children: `++id,
    name,
    birthDate`,
    
    timeline: `++id,
    childId,
    type,
    start,
    end,
    note,
    feeding,
    measure,
    nappy`
});

db.children.add({name: "Max", birthDate: new Date(2017, 1, 1)});


