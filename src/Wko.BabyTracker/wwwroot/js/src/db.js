import Dexie from "dexie";

export let db = new Dexie("BabyTracker");

db.version(1).stores({
  children: `
    ++id,
    name,
    birthDate
    `,

  timeline: `
    ++id,
    childId,
    type,
    start,
    end,
    note,
    feeding,
    measure,
    nappy
    `,
});
