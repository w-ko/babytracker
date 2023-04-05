import { db } from "./db";

export const getChildren = async () => {
  return await db.children.toArray();
};

export const getChild = async (childId) => {
  return await db.children.get(childId);
};

export const createChild = async (child) => {
  await db.children.add(child);
};

export const updateChild = async (childId, ...props) => {
  await db.children.update(childId, ...props);
};

export const deleteChild = async (childId) => {
  await db
    .transaction("rw", db.children, db.timeline, async () => {
      await db.children.delete(childId);
      await db.timeline.where("childId").equals(childId).delete();
    })
    .catch((error) => {
      console.error(error);
    });
};
