import os
import boto3
from botocore.exceptions import ClientError


def get_releases(event, context):
    beverage_group = event['group']
    aws_region = os.environ['AWS_REGION']
    dynamodb = boto3.resource('dynamodb', region_name=aws_region)
    table = dynamodb.Table('SystembolagetReleases')
    beverages = []
    try:
        response = table.get_item(
            Key={
                    'Group': beverage_group
                }
        )
    except ClientError as e:
        print(e.response['Error']['Message'])
    else:
        if 'Item' in response:
            beverages = response['Item']['Beverages']

    return {
        'data': beverages
    }
