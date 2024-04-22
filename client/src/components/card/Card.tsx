import React from 'react'

interface Props {
    company: string,

}

const Card: React.FC<Props> = ({ company }: Props): JSX.Element => {
    return (
        <div className='card' >
            {company}
        </div>
    )
}

export default Card