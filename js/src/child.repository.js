import {db} from "./db";

export const getChildren = () => {
    return db.children.toArray();
}

export const getChild = (childId) => {
    return db.children.get(childId);
}

export const createChild = (child) => {
    db.children.add(child);
}

export const updateChild = (childId, ...props) => {
    db.children.update(childId, ...props);
}

export const deleteChild = (childId) => {
    db.transaction("rw", db.children, db.timeline, () => {
        db.children.delete(childId);
        db.timeline.where("childId").equals(childId).delete();
    }).catch(error => {
        console.error(error);
    });
}
