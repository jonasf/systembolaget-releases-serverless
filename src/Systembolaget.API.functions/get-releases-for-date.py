import os
import boto3
import json
import decimal
from botocore.exceptions import ClientError


class DecimalEncoder(json.JSONEncoder):
    def default(self, o):
        if isinstance(o, decimal.Decimal):
            if o % 1 > 0:
                return float(o)
            else:
                return int(o)
        return super(DecimalEncoder, self).default(o)


def get_releases(event, context):
    release_date = event['date']
    beverage_group = event['group']
    aws_region = os.environ['AWS_REGION']
    dynamodb = boto3.resource('dynamodb', region_name=aws_region)
    table = dynamodb.Table('SystembolagetReleases')
    beverages = []
    try:
        response = table.get_item(
            Key={
                    'ReleaseDate': release_date,
                    'Group': beverage_group
                }
        )
    except ClientError as e:
        print(e.response['Error']['Message'])
    else:
        if 'Item' in response:
            beverages = json.dumps(response['Item']['Beverages'],
                                   indent=4, cls=DecimalEncoder)

    return {
        'data': beverages
    }
