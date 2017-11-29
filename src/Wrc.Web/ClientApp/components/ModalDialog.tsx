import * as React from "react";

interface ModalDialogProps {
    show: boolean;
    onClose: any;
    children?: any;
}

export class ModalDialog extends React.Component<ModalDialogProps, {}> {
    close(e: any) {
        e.preventDefault();

        if (this.props.onClose) {
            this.props.onClose(e);
        }
    }

    render() {
        // Render nothing if the "show" prop is false

        if (this.props.show !== true) {
            return null;
        }

        // The gray background
        const backdropStyle = {
            position: 'absolute' as "absolute",
            width: '100%',
            height: '100%',
            top: '0px',
            left: '0px',
            zIndex: 9998,
            background: 'rgba(0, 0, 0, 0.3)'
        };

        // The modal "window"
        const modalStyle = {
            position: 'absolute' as "absolute",
            top: '50%',
            left: '50%',
            transform: 'translate(-50%, -50%)',
            zIndex: 9999,
            background: '#fff'
        };

        return (
            <div>
                <div style={modalStyle}>
                    {this.props.children}

                    <div className="footer">
                        <button onClick={(e: any) => this.close(e)}>
                            Close
                        </button>
                    </div>
                </div >
                <div style={backdropStyle} onClick={(e: any) => this.close(e)}></div>
            </div>
        );
    }
}