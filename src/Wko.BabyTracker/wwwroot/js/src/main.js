import {getChildren} from "./child.repository";

export * from "./timeline.repository";
export * from "./child.repository";

getChildren().then(console.log);
