import * as React from "react";
import { FormattedDate, FormattedTime } from "react-intl";

import * as ReplaysAppState from "../../store/Replays";
import { AllianceDetails } from "./AllianceDetails";

interface ReplayCardProps {
    replay: ReplaysAppState.ReplayCardModel;
}

export class ReplayCard extends React.Component<ReplayCardProps, {}> {
    render() {
        const replay = this.props.replay;

        if (!replay)
            return null;

        const downloadButtonStyle = {
            margin: "5px auto",
        };

        return (
            <div>
                <div className="columns">
                    <div className="column is-narrow">
                        <figure className="image is-128x128">
                            <img src="https://bulma.io/images/placeholders/128x128.png" />
                        </figure>

                        <a className="button is-primary is-outlined is-small" style={downloadButtonStyle}>
                            <span className="fa fa-download"></span> Download [{replay.downloadCount}]
                        </a>
                    </div>
                    <div className="column">
                        <table className="table is-narrow is-fullwidth">
                            <tbody>
                                <tr>
                                    <th>Map</th>
                                    <td>{replay.mapName}</td>
                                </tr>
                                <tr>
                                    <th>Game mode</th>
                                    <td>{replay.victoryConditionName}</td>
                                </tr>
                                <tr>
                                    <th>Version</th>
                                    <td>{replay.gameVersion}</td>
                                </tr>
                                <tr>
                                    <th>Score to achieve</th>
                                    <td>{replay.scoreLimit}</td>
                                </tr>
                                <tr>
                                    <th>Uploaded</th>
                                    <td>
                                        <FormattedDate value={replay.uploadedAt} /> <FormattedTime value={replay.uploadedAt} />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>

                <div className="columns">
                    <div className="column">
                        <AllianceDetails alliance={replay.bluefor} />
                    </div>
                    <div className="column">
                        <AllianceDetails alliance={replay.redfor} />
                    </div>
                </div>
            </div>
        );
    }
};