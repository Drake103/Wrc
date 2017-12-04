import * as React from "react";

import * as ReplaysAppState from "../../store/Replays";
import { ModalDialog } from "../ModalDialog";
import { ReplayCard } from "./ReplayCard";

type ReplayListProps = ReplaysAppState.ReplaysAppState // ... state we've requested from the Redux store
    & typeof ReplaysAppState.actionCreators;

export class ReplayList extends React.Component<ReplayListProps, {}> {
    handleClick(replay: ReplaysAppState.ReplayRowModel) {
        this.props.expandReplay(replay.id);
    }

    handleClose(replay: ReplaysAppState.ReplayRowModel) {
        this.props.collapseReplay(replay.id);
    }

    render() {
        return (
            <div>
                <table className="table">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Upload date</th>
                            <th>Title</th>
                            <th className="">Players</th>
                            <th>Map</th>
                            <th className="">Game mode</th>
                            <th>Version</th>
                            <th className="">Download</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.replays.map(replay =>
                            <tr key={replay.id}>
                                <td>
                                    <button className="button is-small" onClick={(e: any) => this.handleClick(replay)}>Details</button>
                                    <ModalDialog title={replay.title}
                                        onClose={(e: any) => this.handleClose(replay)}
                                        show={replay.isExpanded}>
                                        <ReplayCard replay={replay.details} />
                                    </ModalDialog>
                                </td>
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
                </table>
            </div>
        );
    }
}