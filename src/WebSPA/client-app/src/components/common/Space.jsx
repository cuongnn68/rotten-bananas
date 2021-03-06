//@ts-check

/**
 * 
 * @param {{height: string, width:string}} props 
 * @returns 
 */
export default function Space(props) {
    let width = props.width || "auto";
    let height = props.height || "auto";
    return (
        <div style={{width, height}} />
    );
}