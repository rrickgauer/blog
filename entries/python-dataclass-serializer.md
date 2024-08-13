

This is a simple wrapper/method for mapping dictionaries to data classes in python.

## Mapper Module

First, we need to install the [dacite](https://github.com/konradhalas/dacite) libray:

```sh
pip install dacite
```

Now, create a new mapper module to handle the dictionary mapping:

```py
from __future__ import annotations
import datetime
import uuid
from dacite.core import from_dict
import dacite
from typing import TypeVar, Type, Dict, List
import enum

T = TypeVar("T")

def _try_map_date_str(day_str: str):
    """Try mapping a date string value"""

    try:
        return datetime.date.fromisoformat(day_str)
    except:
        return datetime.datetime.fromisoformat(day_str).date()

MAPPER_CONFIG = dacite.Config(
    cast = [
        uuid.UUID, 
        enum.Enum
    ],

    type_hooks = {
        datetime.datetime: datetime.datetime.fromisoformat,
        datetime.date: _try_map_date_str,
        datetime.time: datetime.time.fromisoformat,
    },
)



def map_dicts(data: List[Dict], class_type: Type[T]) -> List[T]:
    """Map the dictionaries to the specified type."""
    return [map_dict(d, class_type) for d in data]


def map_dict(data: Dict, class_type: Type[T]) -> T:
    """Map the given dictionary to the specified type"""
    return from_dict(class_type, data, MAPPER_CONFIG)


class IMappable:
    """Have a domain dataclass inherit this class to use ClassName.from_dict(data)."""
    
    @classmethod
    def from_dicts(cls, data: List[Dict]):
        return map_dicts(data, cls)

    @classmethod
    def from_dict(cls, data: Dict):
        return map_dict(data, cls)
```

## Usage

Let's start out with a basic User data class:

```py
from __future__ import annotations
from dataclasses import dataclass
from typing import Optional as Opt
from datetime import datetime
import IMappable


@dataclass
class User(IMappable):
    user_id   : Opt[int]      = None
    email     : Opt[str]      = None
    created_on: Opt[datetime] = None
```

To map dictionaries to a dataclass you can do it like so:

```py
import User

user_dict = dict(
    user_id    = 1,
    email      = 'testing@example.com',
    created_on = None,
)

user_data_class = User.from_dict(user_dict)
print(user_data_class)
```