import {db} from "./db";

export const getTimelineByChildId = (childId) => {
    return db.timeline
             .sortBy('start')
             .where("childId")
             .equals(childId)
             .toArray();
}

export const getTimelineById = (timelineEntryId) => db.timeline.get(timelineEntryId)
export const createTimelineEntry = (timelineEntry) => db.timeline.add(timelineEntry)
export const updateTimelineEntry = (timelineEntryId, ...props) => db.timeline.update(timelineEntryId, ...props)
export const deleteTimelineEntry = (timelineEntryId) => db.timeline.delete(timelineEntryId)
