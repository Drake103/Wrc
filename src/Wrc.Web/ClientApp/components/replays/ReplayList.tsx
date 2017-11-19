import * as React from "react";

import { ReplaysAppState, ReplayRowModel } from "../../store/Replays";
import { ReplayRow } from "./ReplayRow";

export class ReplayList extends React.Component<ReplaysAppState, {}> {
    render() {
        const replayRows = this.props.replays.map((r: ReplayRowModel) => <ReplayRow {...r}/>);
        return (
            <table>
                {replayRows}
            </table>
        );
    }
}