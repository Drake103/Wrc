import * as React from "react";

import { ReplaysAppState, ReplayRowModel } from "../../store/Replays";
import { ReplayRow } from "./ReplayRow";

export class ReplayList extends React.Component<ReplaysAppState, {}> {
    render() {
        const replayRows = this.props.replays.map((r: ReplayRowModel) => <ReplayRow key={r.id} {...r} />);

        return <table className='table'>
            <thead>
                <tr>
                    <th>Upload date</th>
                    <th>Title</th>
                    <th className="centered">Players</th>
                    <th>Map</th>
                    <th className="centered">Game mode</th>
                    <th>Version</th>
                    <th className="centered">Download</th>
                </tr>
            </thead>
            <tbody>
                {this.props.replays.map(replay =>
                    <tr key={replay.id}>
                        <td>{replay.uploadedAt}</td>
                        <td>{replay.title}</td>
                        <td>{replay.playersCount}</td>
                        <td>{replay.mapName}</td>
                        <td>{replay.victoryConditionName}</td>
                        <td>{replay.gameVersion}</td>
                        <td>{replay.downloadCount}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}