import { db } from "./db";

export const getTimelineByChildId = async (childId) => {
  let collection = db.timeline.sortBy("start").where("childId").equals(childId);
  return collection.toArray();
};

export const getTimelineById = async (timelineEntryId) =>
  await db.timeline.get(timelineEntryId);
export const createTimelineEntry = async (timelineEntry) =>
  await db.timeline.add(timelineEntry);
export const updateTimelineEntry = async (timelineEntryId, ...props) =>
  await db.timeline.update(timelineEntryId, ...props);
export const deleteTimelineEntry = async (timelineEntryId) =>
  await db.timeline.delete(timelineEntryId);
